﻿using Fizzy.GridFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fizzy
{
    public partial class Form1 : Form
    {
        List<Fizzy.GPXLoader.Cache> allgc = null;
        AGridPurpose gridPurpose;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Config.FilePath))
                btnLoad_Click(null, null);

            LoadGpxFile();
            radDT.Checked = true;
        }

        private void LoadGpxFile()
        {
            try
            {
                allgc = (new GPXLoader()).LoadGPXWaypoints(Config.FilePath);
                InitializeFilterDropdowns(allgc);
            }
            catch (Exception e)
            {
                //was this the problem? 
                if (!File.Exists(Config.FilePath))
                    MessageBox.Show("File is missing: " + Config.FilePath, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show(e.Message);
                allgc = null;
            }
        }

        private void InitializeFilterDropdowns(List<GPXLoader.Cache> geocaches)
        {
            {
                var years = geocaches.ConvertAll(w => w.Found.Year).Distinct().ToArray();
                Array.Sort(years);
                cboYearFilter.Items.Clear();
                cboYearFilter.Items.Add("All Years");
                foreach (var y in years)
                    cboYearFilter.Items.Add(y);
                cboYearFilter.SelectedIndex = 0;
            }

            {
                var types = geocaches.ConvertAll(w => w.GCType).Distinct().ToArray();
                Array.Sort(types);
                cboTypeFilter.Items.Clear();
                cboTypeFilter.Items.Add("All Types");
                foreach (var t in types)
                    cboTypeFilter.Items.Add(t);
                cboTypeFilter.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// color cell background based on running state
        /// </summary>
        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var cell = grid[e.ColumnIndex, e.RowIndex];
            if (cell.Value is String)
            {
                if ((string)cell.Value == "X")
                    e.CellStyle.BackColor = Color.LightGray;
            }
            else if (cell.Value is int)
            {
                if ((int)cell.Value > 0)
                    e.CellStyle.BackColor = Color.LightGreen;
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var cell = grid[e.ColumnIndex, e.RowIndex];
            var caches = cell.Tag as List<Fizzy.GPXLoader.Cache>;
            if (caches == null) return;

            CreateList(caches, gridPurpose.CacheFormatter, text);
        }

        private void text_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText.Contains('|'))
            {
                string[] parts = e.LinkText.Split(new char[] { '|' });
                if (parts.Length != 2)
                {
                    MessageBox.Show("Internal error.  This link is not set up properly.");
                    return;
                }

                string gc = parts[1].Trim();
                if (parts[0].StartsWith("GC"))
                {
                    System.Diagnostics.Process.Start("http://coord.info/" + gc);
                    return;
                }

                switch (parts[0])
                {
                    case "log":
                        MessageBox.Show(GetLog(gc), "Log(s) for " + gc);
                        return;
                    default:
                        MessageBox.Show("Link type not defined: " + gc);
                        return;
                }
            }
            else
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
        }

        private string GetLog(string gccode)
        {
            return allgc.Find(g => g.Code == gccode).Log;
        }

        /// <summary>
        /// get rid of annying arrow on grid row.
        /// </summary>
        private void grid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);
            e.PaintHeader(DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground | DataGridViewPaintParts.ContentForeground);
            e.Handled = true;
        }

        /// <summary>
        /// size columns according to grid size.
        /// </summary>
        private void grid_SizeChanged(object sender, EventArgs e)
        {
            if (grid.Columns.Count > 0)
            {
                int width = grid.Width;
                width -= grid.RowHeadersWidth;
                var colwidth = width / grid.Columns.Count;
                foreach (DataGridViewColumn col in grid.Columns)
                    col.Width = colwidth;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (dlgGPX.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Config.FilePath = dlgGPX.FileName;
                LoadGpxFile();
                radGridType_CheckedChanged(null, null);
            }
        }

        private void radGridType_CheckedChanged(object sender, EventArgs e)
        {
            if (allgc == null) return;
            if (sender == null) return;
            if (!((RadioButton)sender).Checked) return;

            gridPurpose = GridPurposeFactory.Instance(((RadioButton)sender).Name);

            refreshGridEvent(sender, e);
        }

        private void refreshGridEvent(object sender, EventArgs e)
        {
            if (gridPurpose != null)
            {
                grid.Rows.Clear();
                List<GPXLoader.Cache> filteredGC = ApplyFilters(allgc);
                lblCount.Text = filteredGC.Count.ToString();
                gridPurpose.Initialize(filteredGC, grid);
                grid_SizeChanged(null, null);
            }
        }

        private List<GPXLoader.Cache> ApplyFilters(List<GPXLoader.Cache> allgc)
        {
            List<GPXLoader.Cache> filteredGC = null;
            if (cboYearFilter.SelectedIndex > 0)
                filteredGC = allgc.Where(c => c.Found.Year == (int)cboYearFilter.SelectedItem).ToList();

            if (cboTypeFilter.SelectedIndex > 0)
                if (filteredGC == null)
                    filteredGC = allgc.Where(c => c.GCType == (string)cboTypeFilter.SelectedItem).ToList();
                else
                    filteredGC = filteredGC.Where(c => c.GCType == (string)cboTypeFilter.SelectedItem).ToList();

            if (filteredGC == null) return allgc;
            else return filteredGC;
        }

        private void btnAvengedDnfs_Click(object sender, EventArgs e)
        {
            var avenged = allgc.Where(g => g.sDNFDate != null);
            var formatter = new AvengedFormatter();
            CreateList(avenged, formatter.CacheFormatter, text);
        }

        internal static void CreateList(IEnumerable<GPXLoader.Cache> caches, ACacheFormatter.CacheFmtDelegate cacheFormatter, RichTextBoxLinks.RichTextBoxEx textBox)
        {
            textBox.Text = string.Empty; //clear formatting

            //internal links will be in the form directive:GC0000
            Regex hyper = new Regex("(\\w+):(GC\\w+)");

            bool addTitle = true;
            foreach (var c in caches.OrderByDescending(a => a.sFoundDate))
            {
                string s = cacheFormatter(addTitle, caches, c).ToString();

                int idx = 0;
                var matches = hyper.Matches(s);
                for (int i = 0; i < matches.Count; i++)
                {
                    var match = matches[i];
                    textBox.SelectedText = s.Substring(idx, match.Index - idx);
                    textBox.InsertLink(match.Groups[1].Value, match.Groups[2].Value + " ");  //had to add space due to buggy custom rich text control.
                    idx = match.Index + match.Length;
                }
                textBox.SelectedText = s.Substring(idx, s.Length - idx);

                addTitle = false;
            }

            //embolden the first line
            textBox.Select(0, textBox.Text.IndexOf('\n'));
            textBox.SelectionFont = new Font(textBox.Font, FontStyle.Bold);
        }
    }

}

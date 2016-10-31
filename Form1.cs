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
            LoadGpxFile();
            radDT.Checked = true;
        }

        private bool LoadGpxFile()
        {
            try
            {
                allgc = (new GPXLoader()).LoadGPXWaypoints(Config.FilePath);
                return true;
            }
            catch (Exception e)
            {
                //was this the problem? 
                if (File.Exists(Config.FilePath))
                    MessageBox.Show("File is missing: " + Config.FilePath,  string.Empty,  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                allgc = null;
                return false;
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
            System.Diagnostics.Process.Start(e.LinkText);
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
            int width = grid.Width;
            width -= grid.RowHeadersWidth;
            var colwidth = width / grid.Columns.Count;
            foreach (DataGridViewColumn col in grid.Columns)
                col.Width = colwidth;
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

            grid.Rows.Clear();
            gridPurpose = GridPurposeFactory.Instance(((RadioButton)sender).Name);

            gridPurpose.Initialize(allgc, grid);

            grid_SizeChanged(null, null);
        }

        private void btnAvengedDnfs_Click(object sender, EventArgs e)
        {
            var avenged = allgc.Where(g => g.sDNFDate != null);
            var formatter = new AvengedFormatter();
            CreateList(avenged, formatter.CacheFormatter, text);
        }

        internal static void CreateList(IEnumerable<GPXLoader.Cache> caches, ACacheFormatter.CacheFmtDelegate cacheFormatter, System.Windows.Forms.RichTextBox textBox)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in caches.OrderByDescending(a => a.sFoundDate))
            {
                sb.Append(cacheFormatter(sb.Length == 0, caches, c));
            }

            textBox.Text = string.Empty; //clear formatting
            textBox.Text = sb.ToString();

            //embolden the first line
            textBox.Select(0, textBox.Text.IndexOf('\n'));
            textBox.SelectionFont = new Font(textBox.Font, FontStyle.Bold);
        }
    }

}

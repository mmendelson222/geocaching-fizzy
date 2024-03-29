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
        IEnumerable<Fizzy.GPXLoader.Cache> listedCaches = null;
        AGridPurpose gridPurpose;
        int selectedCol, selectedRow;
        bool suppressDialog = false;

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
                var loader = new GPXLoader(Config.FilePath);
                allgc = loader.LoadGPXWaypoints();

                //count the total number of days the geocacher found/attended. 
                var daycount = allgc.GroupBy(g => string.Format("{0}{1}{2}", g.Found.Year, g.Found.Month, g.Found.Day)).Count();

                GPXLoader.GpxMeta meta = loader.GetGpxMeta();
                txtGpxMeta.Text = string.Format("User: {0}\r\nDate: {1:MMM d, yyyy}\r\nDays: {2}", meta.User, meta.Date, daycount);

                filterControl1.Initialize(allgc);
            }
            catch (Exception e)
            {
                //was this the problem? 
                if (!File.Exists(Config.FilePath))
                    MessageBox.Show("File is missing: " + Config.FilePath, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show(e.Message);
                //MessageBox.Show(e.Message + "\n" + e.StackTrace);
                allgc = null;
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
            SelectCell(e.ColumnIndex, e.RowIndex);
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    SelectCell(grid.SelectedCells[0].ColumnIndex, grid.SelectedCells[0].RowIndex);
                    e.Handled = true;
                    break;

                case 9:
                    grid.Parent.SelectNextControl(grid, (e.Modifiers & Keys.Shift) == 0, true, true, true);
                    e.Handled = true;
                    break;
            }
        }

        private void SelectCell(int col, int row)
        {
            this.selectedRow = row;
            this.selectedCol = col;
            RefreshCurrentSelected();
        }

        private void RefreshCurrentSelected()
        {
            if (selectedRow < 0 || selectedCol < 0) return;

            var cell = grid[selectedCol, selectedRow];
            var caches = cell.Tag as List<Fizzy.GPXLoader.Cache>;
            if (caches == null) return;
            CreateList(caches, text);
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
                if (dlgGPX.FileName.EndsWith("zip"))
                {
                    string tmp = Path.GetTempPath() + "fizzy\\";
                    if (Directory.Exists(tmp))
                        Directory.Delete(tmp, true);
                    System.IO.Compression.ZipFile.ExtractToDirectory(dlgGPX.FileName, tmp);
                    //expect zip file to contain exactly one gpx file. 
                    string[] files = System.IO.Directory.GetFiles(tmp);
                    Config.FilePath = files[0];
                }
                else
                {
                    //it's a gpx
                    Config.FilePath = dlgGPX.FileName;
                }
                LoadGpxFile();
            }
        }

        private void radGridType_CheckedChanged(object sender, EventArgs e)
        {
            if (allgc == null) return;
            if (sender == null) return;
            if (!((RadioButton)sender).Checked) return;

            gridPurpose = GridPurposeFactory.Instance(((RadioButton)sender).Name);
            selectedCol = selectedRow = 0;
            splitGrid.Panel1Collapsed = !gridPurpose.UseGrid;
            
            refreshGridEvent(sender, e);
        }

        private void filterFormChanged(object sender, string filterStatus)
        {
            //lblFilterStatus.Text = filterStatus;
            refreshGridEvent(sender, null);
        }

        private void refreshGridEvent(object sender, EventArgs e)
        {
            if (gridPurpose == null) return;
            
            //just refresh the current list. 
            if (sender is CheckBox)
            {
                if (((CheckBox)sender).Name == "chkSimpleList")
                {
                    RefreshCurrentSelected();
                    return;
                }
            }

            var filteredGC = gridPurpose.Filter(allgc);
            filteredGC = ApplyFilters(filteredGC);

            if (gridPurpose.UseGrid)
            {
                grid.Rows.Clear();
                lblCount.Text = filteredGC.Count.ToString();
                gridPurpose.Initialize(filteredGC, grid);
                grid.ClearSelection();
                text.Clear();
                grid_SizeChanged(null, null);
                btnExport.Enabled = false;
            }
            else
            {
                //simply populate the text box with everything.
                text.Clear();
                CreateList(filteredGC, text);
            }
        }

        private List<GPXLoader.Cache> ApplyFilters(List<GPXLoader.Cache> allgc)
        {
            List<GPXLoader.Cache> filteredGC = allgc.ToList();
            if (filterControl1.SelectedYear > 0)
                filteredGC = filteredGC.Where(c => c.Found.Year == filterControl1.SelectedYear).ToList();

            if (filterControl1.SelectedCacheType != null)
                switch (filterControl1.SelectedCacheType)
                {
                    case FilterControl.EVENTS: filteredGC = filteredGC.Where(c => c.GCType.Contains("Event")).ToList(); break;
                    case FilterControl.NOT_EVENTS: filteredGC = filteredGC.Where(c => !c.GCType.Contains("Event")).ToList(); break;
                    default: filteredGC = filteredGC.Where(c => c.GCType == filterControl1.SelectedCacheType).ToList(); break;
                }


            if (filterControl1.SelectedState != null)
                filteredGC = filteredGC.Where(c => c.State == filterControl1.SelectedState).ToList();

            if (filterControl1.SelectedCountry != null)
                filteredGC = filteredGC.Where(c => c.Country == filterControl1.SelectedCountry).ToList();

            if (filterControl1.ArchivedStatus != null)
            {
                bool status = (filterControl1.ArchivedStatus == "Archived");
                filteredGC = filteredGC.Where(c => c.Archived == status).ToList();
            }

            if (filterControl1.Search != null)
            {
                switch (filterControl1.SearchMode)
                {
                    case FilterControl.eSearchMode.title:
                        filteredGC = filteredGC.Where(c => (c.Name.IndexOf(filterControl1.Search, 0, StringComparison.CurrentCultureIgnoreCase) > -1)).ToList();
                        break;
                    case FilterControl.eSearchMode.foundLog:
                        filteredGC = filteredGC.Where(c => (c.Log.IndexOf(filterControl1.Search, 0, StringComparison.CurrentCultureIgnoreCase) > -1)).ToList();
                        break;
                    case FilterControl.eSearchMode.description:
                        filteredGC = filteredGC.Where(c => (c.Description.IndexOf(filterControl1.Search, 0, StringComparison.CurrentCultureIgnoreCase) > -1)).ToList();
                        break;
                    default:
                        break;
                }
            }

            if (filterControl1.FilterByAttributes)
            {
                var filterOnUs = AttributeFilterDlg.AllAttributes.Where(a => a.Selected);

                if (AttributeFilterDlg.Operation == AttributeFilterDlg.operation.Or)
                {
                    List<GPXLoader.Cache> criteriaMet = new List<GPXLoader.Cache>(filteredGC.Count);

                    //start with a shallow clone of the list.  
                    List<GPXLoader.Cache> criteriaNotMet = new List<GPXLoader.Cache>(filteredGC.Count);
                    filteredGC.ForEach((item) =>
                    {
                        criteriaNotMet.Add(item);
                    });

                    foreach (var att in filterOnUs)
                    {
                        System.Diagnostics.Debug.WriteLine(att.Description + " " + att.id + " " + att.On);
                        //find the items that meet this criteria
                        var attsFound = criteriaNotMet.Where(c => c.Attributes.Exists(a => a.on == att.On && a.num == att.id)).ToList();

                        //OR logic:  add these to met criteria.
                        criteriaMet.AddRange(attsFound);

                        //shrink the pool so we don't get duplicates.
                        criteriaNotMet = criteriaNotMet.Where(c => c.Attributes.Exists(a => a.on != att.On || a.num != att.id) || c.Attributes.Count == 0).ToList();
                    }
                    filteredGC = criteriaMet;
                }
                else
                {
                    foreach (var att in filterOnUs)
                    {
                        System.Diagnostics.Debug.WriteLine(att.Description + " " + att.id + " " + att.On);
                        //find the items that meet this criteria
                        filteredGC = filteredGC.Where(c => c.Attributes.Exists(a => a.on == att.On && a.num == att.id)).ToList();
                    }
                }
            }

            return filteredGC;
        }

        private string commas(string s)
        {
            if (s.Contains(","))
                return string.Format("\"{0}\"", s);
            else
                return s;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            dlgSaveExport.FileName = gridPurpose.ExportFormatter(listedCaches);
            if (dlgSaveExport.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder(
                    "found,gc code,hidden,cache name,type,difficulty,terrain,status,owner,placed by,region,country\n");
                foreach (var c in listedCaches.OrderByDescending(a => a.sFoundDate))
                {
                    sb.AppendFormat("{0:MM-dd-yy},{1},{2:MM-dd-yy},{3},{4},{5},{6},{7},{8},{9},{10},{11}\n",
                        c.Found,
                        c.Code,
                        c.Hidden,
                        commas(c.Name),
                        c.GCType,
                        c.Difficulty,
                        c.Terrain,
                        c.Archived ? "archived" : "active",
                        commas(c.Owner),
                        commas(c.PlacedBy),
                        commas(c.State),
                        c.Country);
                }
                try
                {
                    File.WriteAllText(dlgSaveExport.FileName, sb.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        internal void CreateList(IEnumerable<GPXLoader.Cache> caches, RichTextBoxLinks.RichTextBoxEx textBox)
        {
            if (caches.Count() > 1000 && !suppressDialog)
            {
                var result = MessageBox.Show(this, string.Format("Showing {0} caches might take a while.  Are you sure?\n\nCancel to suppress this message for now.", caches.Count()), "Annoying Dialog", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.No: return;
                    case DialogResult.Cancel: suppressDialog = true; break;
                }
            }

            if (caches.Count() > 400)
                this.Cursor = Cursors.WaitCursor;

            btnExport.Enabled = caches.Count() > 0;
            listedCaches = caches;
            textBox.Text = string.Empty; //clear formatting
            textBox.SelectedText = gridPurpose.TitleFormatter(caches) + "\n";

            //internal links will be in the form directive:GC0000
            Regex hyper = new Regex("(\\w+):(GC\\w+)");

            foreach (var c in caches.OrderByDescending(a => a.sFoundDate))
            {
                string s;
                if (filterControl1.simpleListing)
                    s = ACacheFormatter.SimpleCacheFormatter(c);
                else
                    s = gridPurpose.CacheFormatter(c);

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
            }

            //embolden the first line
            textBox.Select(0, textBox.Text.IndexOf('\n'));
            textBox.SelectionFont = new Font(textBox.Font, FontStyle.Bold);
            this.Cursor = Cursors.Default;
        }

    }
}

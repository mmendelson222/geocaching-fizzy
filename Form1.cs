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
            catch
            {
                allgc = null;
                return false;
            }
        }

        private void LoadDTGrid()
        {
            grid.ColumnCount = 9;

            for (int d = 0; d < 9; d++)
            {
                var row = new DataGridViewRow();
                string diff = ((d + 2) * 0.5).ToString();
                row.HeaderCell.Value = diff;

                for (int t = 0; t < 9; t++)
                {
                    string terr = ((t + 2) * 0.5).ToString();

                    //initialization for columns
                    if (d == 0)
                    {
                        var col = grid.Columns[t];
                        col.Name = terr;
                        col.DataPropertyName = "count";
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    var thisDT = allgc.Where(g => g.Difficulty == diff && g.Terrain == terr);

                    //Debug.Write(string.Format("{0}/{1}", diff, terr));
                    //Debug.Write(string.Format("{0} ", thisDT.Count()));

                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = thisDT.Count(),
                        Tag = thisDT.ToList()
                    });
                }

                grid.Rows.Add(row);

                grid_SizeChanged(null, null);
            }
        }

        private void dt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = grid[e.ColumnIndex, e.RowIndex];
            var caches = cell.Tag as List<Fizzy.GPXLoader.Cache>;
            if (caches == null) return;

            StringBuilder sb = new StringBuilder();
            foreach (var c in caches.OrderByDescending(a => a.sDate))
            {
                if (sb.Length == 0)
                    sb.AppendFormat("Difficulty: {0}, Terrain {1}\n", c.Difficulty, c.Terrain);
                sb.AppendFormat("{0:MM-dd-yy} {1} {2} http://coord.info/{3} {4}\n", c.Date, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
            }

            text.Text = string.Empty; //clear formatting
            text.Text = sb.ToString();
            //embolden the first line

            text.Select(0, text.Text.IndexOf('\n'));
            text.SelectionFont = new Font(text.Font, FontStyle.Bold);
        }

        private void LoadFindsByDayGrid()
        {
            grid.ColumnCount = 31;

            for (int m = 0; m < 12; m++)
            {
                var row = new DataGridViewRow();

                for (int d = 0; d < 31; d++)
                {
                    var month = m + 1;
                    var day = d + 1;

                    DateTime dt = new DateTime();
                    try
                    {
                        dt = new DateTime(2016, month, day);
                    }
                    catch
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell()
                        {
                            Value = "X",
                            Tag = null
                        });
                        continue;
                    }

                    if (d == 0)
                    {
                        row.HeaderCell.Value = dt.ToString("MMM");
                    }

                    //initialization for columns
                    if (m == 0)
                    {
                        var col = grid.Columns[d];
                        col.Name = day.ToString();
                        col.DataPropertyName = "count";
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    //var sDate = dt.ToString("MM-dd");

                    var thisDT = allgc.Where(g => g.Date.Month == dt.Month && g.Date.Day == dt.Day);

                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = thisDT.Count(),
                        Tag = thisDT.ToList()
                    });
                }

                grid.Rows.Add(row);

                grid_SizeChanged(null, null);
            }
        }

        private void cal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = grid[e.ColumnIndex, e.RowIndex];
            var caches = cell.Tag as List<Fizzy.GPXLoader.Cache>;
            if (caches == null) return;

            StringBuilder sb = new StringBuilder();

            foreach (var c in caches.OrderByDescending(a => a.sDate))
            {
                if (sb.Length == 0)
                    sb.AppendFormat("Caches found on: {0:M-d}\n", c.Date);
                sb.AppendFormat("{5:yyyy} {0} {1}/{2} {3} http://coord.info/{4} {6}\n", c.Name, c.Difficulty, c.Terrain, c.State, c.Code, c.Date, (c.Archived ? "(archived)" : string.Empty));
            }

            text.Text = string.Empty; //clear formatting
            text.Text = sb.ToString();
            //embolden the first line

            text.Select(0, text.Text.IndexOf('\n'));
            text.SelectionFont = new Font(text.Font, FontStyle.Bold);
        }

        private void LoadFindsByCacheMonth()
        {
            grid.ColumnCount = 12;

            //row: year, column: month
            int thisYear = DateTime.Now.Year;
            int thisMonth = DateTime.Now.Month;

            for (int year = 2000; year <= thisYear; year++)
            {
                var row = new DataGridViewRow();

                for (int m = 0; m < 12; m++)
                {
                    var month = m + 1;

                    //initialization for columns
                    if (year == 2000)
                    {
                        var col = grid.Columns[m];
                        col.Name = new DateTime(2000, m + 1, 1).ToString("MMM");
                        col.DataPropertyName = "count";
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    if (m == 0)
                    {
                        row.HeaderCell.Value = year.ToString();
                    }

                    if ((year == 2000 && m < 4) || (year == thisYear && month > thisMonth))
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell()
                        {
                            Value = "X",
                            Tag = null
                        });
                        continue;
                    }

                    var placedThisMonth = allgc.Where(g => g.Hidden.Month == month && g.Hidden.Year == year);

                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = placedThisMonth.Count(),
                        Tag = placedThisMonth.ToList()
                    });
                }

                grid.Rows.Add(row);

                grid_SizeChanged(null, null);
            }
        }

        private void jasmer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = grid[e.ColumnIndex, e.RowIndex];
            var caches = cell.Tag as List<Fizzy.GPXLoader.Cache>;
            if (caches == null) return;

            StringBuilder sb = new StringBuilder();

            foreach (var c in caches.OrderByDescending(a => a.sDate))
            {
                if (sb.Length == 0)
                    sb.AppendFormat("Caches hidden in the month of: {0:M-yyyy}\n", c.Hidden);
                sb.AppendFormat("{0:MM-dd-yy} {1} {2} http://coord.info/{3} {4}\n", c.Date, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
            }

            text.Text = string.Empty; //clear formatting
            text.Text = sb.ToString();
            //embolden the first line

            text.Select(0, text.Text.IndexOf('\n'));
            text.SelectionFont = new Font(text.Font, FontStyle.Bold);
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

            if (radDT.Checked)
                dt_CellClick(sender, e);
            else if (radCalendar.Checked)
                cal_CellClick(sender, e);
            else if (radJasmer.Checked)
                jasmer_CellClick(sender, e);
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

        private void grid_SizeChanged(object sender, EventArgs e)
        {
            int width = grid.Width;
            //width -= 10;
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
            if (allgc != null)
            {
                grid.Rows.Clear();
                if (radDT.Checked)
                    LoadDTGrid();
                else if (radCalendar.Checked)
                    LoadFindsByDayGrid();
                else if (radJasmer.Checked)
                    LoadFindsByCacheMonth();
            }
        }
    }

}

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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string gpx = @"C:\dev\aws\keys\10130560.gpx";

            if (Config.FilePath != null)
            {
                LoadGrid(Config.FilePath);
            }
            else
            {
                btnLoad_Click(null, null);
            }
        }

        private void LoadGrid(string gpx)
        {
            var loader = new GPXLoader();
            var allgc = loader.LoadGPXWaypoints(gpx);

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var cell = grid[e.ColumnIndex, e.RowIndex];
            var caches = cell.Tag as List<Fizzy.GPXLoader.Cache>;
            if (caches == null) return;

            StringBuilder sb = new StringBuilder();
            foreach (var c in caches.OrderByDescending(a => a.sDate))
            {
                if (sb.Length == 0)
                    sb.AppendFormat("Difficulty: {0}, Terrain {1}\n", c.Difficulty, c.Terrain);
                sb.AppendFormat("{0:MM-dd-yy} {1} {2} http://coord.info/{3}\n", c.Date, c.Name, c.State, c.Code);
            }

            text.Text = string.Empty; //clear formatting
            text.Text = sb.ToString();
            //embolden the first line

            text.Select(0, text.Text.IndexOf('\n'));
            text.SelectionFont = new Font(text.Font, FontStyle.Bold);
        }


        public class GridCellContent
        {
            public int count;
            public List<Fizzy.GPXLoader.Cache> gcs;
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
                LoadGrid(Config.FilePath);
            }
        }

    }

}

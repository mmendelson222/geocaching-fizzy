using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fizzy.GridFunctions
{
    class JasmerGridPurpose : AGridPurpose
    {
        internal override void Initialize(List<GPXLoader.Cache> allgc, System.Windows.Forms.DataGridView grid)
        {
            grid.ColumnCount = 12;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
       
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
            }
        }

        internal override StringBuilder CacheFormatter(bool firstLine, IEnumerable<GPXLoader.Cache> caches, GPXLoader.Cache c)
        {
            StringBuilder sb = new StringBuilder();
            if (firstLine)
                sb.AppendFormat("Caches hidden in the month of: {0:M-yyyy}\n", c.Hidden);
            sb.AppendFormat("{0:MM-dd-yy} {1} {2} http://coord.info/{3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
            return sb;
        }
    }
}

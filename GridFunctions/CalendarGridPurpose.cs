using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fizzy.GridFunctions
{
    class CalendarGridPurpose : AGridPurpose
    {
        internal override void Initialize(List<GPXLoader.Cache> allgc, System.Windows.Forms.DataGridView grid)
        {
            grid.ColumnCount = 31;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;

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

                    var thisDT = allgc.Where(g => g.Found.Month == dt.Month && g.Found.Day == dt.Day);

                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = thisDT.Count(),
                        Tag = thisDT.ToList()
                    });
                }

                grid.Rows.Add(row);
            }
        }

        internal override string CacheFormatter(GPXLoader.Cache c)
        {
            return String.Format("{5:yyyy} {0} {1}/{2} {3} {4}:{4} log:{4} {6}\n", c.Name, c.Difficulty, c.Terrain, c.State, c.Code, c.Found, (c.Archived ? "(archived)" : string.Empty));
        }

        internal override string TitleFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            if (caches.Count() == 0) return string.Empty;
            GPXLoader.Cache c = caches.First();
            return String.Format("Caches found on: {0:M-d}", c.Found);
        }

        internal override string ExportFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            GPXLoader.Cache c = caches.First();
            return String.Format("Found {0:M-d}", c.Found);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fizzy.GridFunctions
{
    class DTGridPurpose : AGridPurpose
    {
        internal override void Initialize(List<GPXLoader.Cache> allgc, System.Windows.Forms.DataGridView grid)
        {
            grid.ColumnCount = 9;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;

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

                grid.Invalidate();
            }
        }

        internal override string CacheFormatter(GPXLoader.Cache c)
        {
            return String.Format("{0:MM-dd-yy} {1} {2} {3}:{3} log:{3} {4} \n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
        }

        internal override string TitleFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            GPXLoader.Cache c = caches.First();
            return String.Format("Difficulty: {0}, Terrain: {1}", c.Difficulty, c.Terrain);
        }

        internal override string ExportFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            GPXLoader.Cache c = caches.First();
            return String.Format("Difficulty {0} Terrain {1}", c.Difficulty, c.Terrain);
        }
    }
}

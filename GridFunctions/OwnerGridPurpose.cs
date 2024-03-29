﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fizzy.GridFunctions
{
    class OwnerGridPurpose : AGridPurpose
    {
        internal override void Initialize(List<GPXLoader.Cache> allgc, System.Windows.Forms.DataGridView grid)
        {
            grid.ColumnCount = 3;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var byOwner = allgc.GroupBy(c => c.Owner).OrderByDescending(g=>g.Count());

            //initialization for columns
            var iCol = 0;
            var col = grid.Columns[iCol++];
            col.Name = "Owner";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            
            col = grid.Columns[iCol++];
            col.Name = "Count";
            col.DataPropertyName = "count";
            
            col = grid.Columns[iCol++];
            col.Name = "Percent";
            col.DataPropertyName = "percent";
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            int totCache = allgc.Count;
            int count = 0;
            const int MAX = 500;
            foreach (var o in byOwner)
            {
                var cacheList = o.ToList();
                OwnerData od = new OwnerData()
                {
                    Owner = o.First().Owner,
                    Count = o.Count()
                };
                od.Percent = string.Format("{0:#.##}%", 100.0 * (float)od.Count / (float)totCache);

                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = od.Owner,
                    Tag = cacheList
                });
                row.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = od.Count,
                    Tag = cacheList
                });
                row.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = od.Percent,
                    Tag = cacheList
                });

                ++count;
                row.HeaderCell.Value = (count).ToString();
                grid.Rows.Add(row);

                if (count == MAX)
                    break;
            }
        }

        internal override string CacheFormatter(GPXLoader.Cache c)
        {
            return String.Format("{0:MM-dd-yy} {1} {2} {3}:{3} log:{3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
        }

        internal override string TitleFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            if (caches.Count() == 0) return string.Empty;
            GPXLoader.Cache c = caches.First();
            return String.Format("Caches hidden by: {0}", c.Owner);
        }

        internal override string ExportFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            GPXLoader.Cache c = caches.First();
            return String.Format("Hidden by {0}", c.Owner);
        }
    }

    public class OwnerData
    {
        public string Owner;
        public int Count;
        public string Percent; 
    }
}

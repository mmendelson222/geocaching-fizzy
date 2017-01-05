using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzy.GridFunctions
{
    class ListAllPurpose : AGridPurpose
    {
        internal override void Initialize(List<GPXLoader.Cache> allgc, System.Windows.Forms.DataGridView grid)
        {
            //do nothing.
        }

        internal override StringBuilder CacheFormatter(bool firstLine, IEnumerable<GPXLoader.Cache> caches, GPXLoader.Cache c)
        {
            StringBuilder sb = new StringBuilder();
            if (firstLine)
                sb.AppendFormat("Caches\n", c.Hidden);
            sb.AppendFormat("{0:MM-dd-yy} {1} {2} {3}:{3} log:{3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
            return sb;
        }

        internal override bool UseGrid { get { return false; } }
    }
}

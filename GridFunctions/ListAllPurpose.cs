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

        internal override String CacheFormatter(bool title, IEnumerable<GPXLoader.Cache> caches, GPXLoader.Cache c)
        {
            if (title)
                return String.Format("Caches\n", c.Hidden);
            else
                return String.Format("{0:MM-dd-yy} {1} {2} {3}:{3} log:{3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
        }

        internal override bool UseGrid { get { return false; } }
    }
}

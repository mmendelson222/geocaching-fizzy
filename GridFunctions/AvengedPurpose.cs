using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzy.GridFunctions
{
    class AvengedPurpose : AGridPurpose
    {
        internal override String CacheFormatter(bool title, IEnumerable<GPXLoader.Cache> caches, GPXLoader.Cache c)
        {
            if (title)
                return String.Format("Avenged DNF's (count: {0})\n", caches.Count());
            else
                return String.Format("{0:MM-dd-yy} dnf: {5:MM-dd-yy} {1} {2} {3}:{3} log:{3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty), c.DNF);
        }

        internal override List<GPXLoader.Cache> Filter(List<GPXLoader.Cache> allgc)
        {
            return allgc.Where(g => g.sDNFDate != null).ToList();
        }

        internal override bool UseGrid { get { return false; } }
    }
}

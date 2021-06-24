using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzy.GridFunctions
{
    class AvengedPurpose : AGridPurpose
    {
        internal override List<GPXLoader.Cache> Filter(List<GPXLoader.Cache> allgc)
        {
            return allgc.Where(g => g.sDNFDate != null).ToList();
        }

        internal override string CacheFormatter(GPXLoader.Cache c)
        {
            return String.Format("{0:MM-dd-yy} dnf: {5:MM-dd-yy} {1} {2} {3}:{3} log:{3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty), c.DNF);
        }

        internal override string TitleFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            if (caches.Count() == 0) return string.Empty;
            return String.Format("Avenged DNF's (count: {0})", caches.Count());
        }

        internal override string ExportFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            return "Avenged DNF list";
        }

        internal override bool UseGrid { get { return false; } }
    }
}

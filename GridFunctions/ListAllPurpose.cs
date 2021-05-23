using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzy.GridFunctions
{
    class ListAllPurpose : AGridPurpose
    {
        internal override string CacheFormatter(GPXLoader.Cache c)
        {
            return String.Format("{0:MM-dd-yy} {1} {2} {3}:{3} log:{3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
        }

        internal override string TitleFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            GPXLoader.Cache c = caches.First();
            return String.Format("Caches", c.Hidden);
        }

        internal override string ExportFormatter(IEnumerable<GPXLoader.Cache> caches)
        {
            return TitleFormatter(caches);
        }

        internal override bool UseGrid { get { return false; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzy.GridFunctions
{
    class AvengedFormatter : ACacheFormatter
    {
        internal override StringBuilder CacheFormatter(bool firstLine, IEnumerable<GPXLoader.Cache> caches, GPXLoader.Cache c)
        {
            StringBuilder sb = new StringBuilder();
            if (firstLine)
                sb.AppendFormat("Avenged DNF's (count: {0})\n", caches.Count());
            sb.AppendFormat("{0:MM-dd-yy} dnf: {5:MM-dd-yy} {1} {2} http://coord.info/{3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty), c.DNF);
            return sb;
        }
    }
}

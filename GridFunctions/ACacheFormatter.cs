using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzy.GridFunctions
{
    //Each grid contains logic to format its cache list.  
    internal abstract class ACacheFormatter
    {
        abstract internal String CacheFormatter(GPXLoader.Cache c);
        abstract internal String TitleFormatter(IEnumerable<GPXLoader.Cache> caches);
        abstract internal String ExportFormatter(IEnumerable<GPXLoader.Cache> caches);

        //this is used if "simple listing" is checked.  Not sure if needed.
        internal static String SimpleCacheFormatter(GPXLoader.Cache c)
        {
            return String.Format("{0:MM-dd-yy} {1} {2} {3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
        }
    }
}

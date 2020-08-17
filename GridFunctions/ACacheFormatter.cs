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
        //delegate allows us to pass a pointer to the CacheFormatter function.
        internal delegate String CacheFmtDelegate(bool title, IEnumerable<GPXLoader.Cache> caches, GPXLoader.Cache c);

        abstract internal String CacheFormatter(bool title, IEnumerable<GPXLoader.Cache> caches, GPXLoader.Cache c);

        //this is an alternative, "simple" description.
        internal static String SimpleCacheFormatter(GPXLoader.Cache c)
        {
            return String.Format("{0:MM-dd-yy} {1} {2} {3} {4}\n", c.Found, c.Name, c.State, c.Code, (c.Archived ? "(archived)" : string.Empty));
        }
    }
}

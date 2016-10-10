using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzy.GridFunctions
{
    internal abstract class AGridPurpose : ACacheFormatter
    {
        abstract internal void Initialize(List<GPXLoader.Cache> allgc, System.Windows.Forms.DataGridView grid);
    }

    internal abstract class ACacheFormatter
    {
        //delegate allows us to pass a pointer to thi
        internal delegate StringBuilder CacheFmtDelegate(bool firstLine, IEnumerable<GPXLoader.Cache> caches, GPXLoader.Cache c);

        abstract internal StringBuilder CacheFormatter(bool firstLine, IEnumerable<GPXLoader.Cache> caches, GPXLoader.Cache c);
    }
}

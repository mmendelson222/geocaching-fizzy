using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzy.GridFunctions
{
    internal abstract class AGridPurpose : ACacheFormatter
    {
        /// <summary>
        /// optionally initialize the grid
        /// </summary>
        internal virtual void Initialize(List<GPXLoader.Cache> allgc, System.Windows.Forms.DataGridView grid) { }

        /// <summary>
        /// optional override for filter, e.g. dnf's
        /// </summary>
        internal virtual List<GPXLoader.Cache> Filter(List<GPXLoader.Cache> allgc) { return allgc; }

        /// <summary>
        /// optionally omit the grid
        /// </summary>
        internal virtual bool UseGrid { get { return true; } }
    }
}

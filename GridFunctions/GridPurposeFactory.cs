using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fizzy.GridFunctions
{
    internal static class GridPurposeFactory
    {
        internal static AGridPurpose Instance(string buttonName)
        {
            switch (buttonName)
            {
                case "radDT": return new DTGridPurpose();
                case "radCalendar": return new CalendarGridPurpose();
                case "radJasmer": return new JasmerGridPurpose();
                case "radOwner": return new OwnerGridPurpose();
                default:
                    throw new Exception("invalid grid purpose");
            }

        }
    }
}

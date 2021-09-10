using System;
using System.Collections;
using System.Linq;

namespace Yffff.View
{
    internal class ContrillerSI
    {
        internal static IEnumerable GetSIComboBox()
        {
            try
            {
                DB.dEntities1 entities1 = new DB.dEntities1();
                return entities1.MaterialSI.Select(x => x.Name).OrderBy(x => x).ToList();
            }
            catch
            {
                throw new Exception("Error BD");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yffff.View
{
    internal class ContrillerMaterial
    {
        internal static List<string> GetMaterial()
        {

            List<string> types = new List<string>();
            try
            {
                DB.dEntities1 entities = new DB.dEntities1();
                types = entities.MaterialTypes.Select(x => x.Name).ToList();
                ;
                types.OrderBy(x => x);
                types.Insert(0, "Без Фильтра");
                return types;
            }
            catch
            {
                throw new Exception("Error DB");
            }
        }
    }
}

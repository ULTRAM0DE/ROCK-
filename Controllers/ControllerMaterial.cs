using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yffff.Controllers
{
    internal class ControllerMaterial
    {
        public static List<View.ModelView.ViewMaterial> GetViewMaterials()
        {
            try
            {
                DB.dEntities1 entities1 = new DB.dEntities1();

                var material = entities1.Materials.ToList();

                List<View.ModelView.ViewMaterial> views = new List<View.ModelView.ViewMaterial>();

                foreach (var item in material)
                {
                    views.Add(new View.ModelView.ViewMaterial(item));
                }

                return views;
            }
            catch
            {
                throw new Exception("Ошибка БД");
            }
           
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yffff.DB;

namespace Yffff.View.ModelView
{
    public class ViewMaterial
    {
        public string Image { get; set; }
        public string NameEndType { get; set; }
        public string Ostatok { get; set; }
        public string MinCol { get; set; }
        public string Providers { get; set; }

        public ViewMaterial()
        {

        }
        public ViewMaterial(DB.Materials materials)
        {
            Image = @"/Image/" + materials.ImagePath;
            NameEndType = $"{materials.MaterialTypes.Name} | {materials.Name}";
            MinCol = $"Минимальное количество {materials.MinCount} шт";
            Ostatok = GetOstatoc(materials);
            Providers = GetProviders(materials);

        }

        public string GetProviders(Materials materials)
        {
            try
            {
                DB.dEntities1 entities1 = new dEntities1();

                var provider = entities1.Receipts.GroupBy(x => x.Id_Material).Select(g => new { Name = g.Key }).ToList();

                List<string> providers = new List<string>();

                foreach(var item in provider )
                {
                    providers.Add(item.Name.ToString());
                }

                string content = "Поставщики:";

                foreach(var item in providers)
                {
                    content += $"{item},";
                }
                return content;
            }
            catch
            {
                throw new Exception("ошибка бд");
            }
        }

        private string GetOstatoc(Materials materials)
        {
            throw new NotImplementedException();
        }
    }
}

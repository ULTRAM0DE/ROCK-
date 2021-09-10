using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yffff.DB;

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

        internal static bool AddMateril(string name, string description, string mincount, string packagecount,
            string price, object image, object si, object typematerial)
        {
            DB.Materials newmaterials = new DB.Materials();


            try
            {
                newmaterials = new DB.Materials();

                View.ModelView.Image im = image as View.ModelView.Image;

                newmaterials.ImagePath = @"/Image\" + im.NameImage;
                newmaterials.Price = Convert.ToInt32(price);
                newmaterials.Name = name;
                newmaterials.MinCount = Convert.ToInt32(mincount);
                newmaterials.CountPerPack = Convert.ToInt32(packagecount);
                newmaterials.Id_MaterialType = GetIdMaterialType(typematerial as string);
                newmaterials.Id_MaterialSI = GetIdMaterialSy(si as string);
                newmaterials.Discriptions = description;
                newmaterials.Id_MaterialColor = 1;
                newmaterials.Id_MaterialStandart = 1;
            }
            catch
            {
                throw new Exception("Ошибка входных параметров");
            }

            if (newmaterials == null)
            {
                return false;
            }
            try
            {
                DB.dEntities1 entities1 = new DB.dEntities1();
                entities1.Materials.Add(newmaterials);
                entities1.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("единицы измерения не найдены в БД");
            }


        }

        private static int GetIdMaterialType(string name)
        {
            try
            {
                DB.dEntities1 entities1 = new DB.dEntities1();
                return entities1.MaterialTypes.Where(x => x.Name == name).First().Id;
            }
            catch
            {
                throw new Exception("единицы измерения  не найдены  в бд");
            }
        }

        private static int GetIdMaterialSy(string name)
        {
            try
            {
                DB.dEntities1 entities1 = new DB.dEntities1();
                return entities1.MaterialSI.Where(x => x.Name == name).First().Id;
            }
            catch
            {
                throw new Exception("Материал не найден в БД");
            }
        }


        internal static bool ChaneMateril(string name, string description, string mincount, string packagecount,
            string price, object image, object si, object typematerial, DB.Materials materials)
        {
            DB.dEntities1 entities1 = new DB.dEntities1();

            DB.Materials newmaterials = entities1.Materials.Find(materials.Id);
            try
            {
                newmaterials = new DB.Materials();

                View.ModelView.Image im = image as View.ModelView.Image;

                newmaterials.ImagePath = @"/Image\" + im.NameImage;
                newmaterials.Price = Convert.ToInt32(price);
                newmaterials.Name = name;
                newmaterials.MinCount = Convert.ToInt32(mincount);
                newmaterials.CountPerPack = Convert.ToInt32(packagecount);
                newmaterials.Id_MaterialType = GetIdMaterialType(typematerial as string);
                newmaterials.Id_MaterialSI = GetIdMaterialSy(si as string);
                newmaterials.Discriptions = description;
                newmaterials.Id_MaterialColor = 1;
                newmaterials.Id_MaterialStandart = 1;
            }
            catch
            {
                throw new Exception("Ошибка входных параметров");
            }

            if (newmaterials == null)
            {
                return false;
            }
            try
            {
               
                entities1.Materials.AddOrUpdate(newmaterials);
                entities1.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("единицы измерения не найдены в БД");
            }


        }
    }
}

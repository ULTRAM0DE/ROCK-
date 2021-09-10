using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yffff.View.ModelView;

namespace Yffff.Controllers
{
    class ConterollerImage
    {
      

        public static List<Image> GetImages()
        {

            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
           
            
            wanted_path += @"\\Image";

            string[] allfolders = Directory.GetFiles(wanted_path);

            List<string> allfoldersJPG = allfolders.Where(c => (c.EndsWith(".jpg")) || (c.EndsWith(".jpeg")) || (c.EndsWith(".png"))).ToList();

            List<View.ModelView.Image> images = new List<Image>();

            foreach (var item in allfoldersJPG)
            {
                images.Add(new Image { Imagepath = item, NameImage = Path.GetFileName(item) });
            }

            return images;
        }

      
    }
}

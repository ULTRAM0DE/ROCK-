using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Yffff.Controllers;

namespace Yffff.View
{
    /// <summary>
    /// Логика взаимодействия для WindowMaterialSklad.xaml
    /// </summary>
    public partial class WindowMaterialSklad : Window
    {
        public WindowMaterialSklad()
        {
            InitializeComponent();
            



            /*{
                new ModelView.ViewMaterial{Image=@"/Image\image_10.jpeg",MinCol="Минимальное количество 2 шт",
                    Ostatok = "Остаток: 2 шт", Providers="Поставщик: Рога и копыта, СГК, и еще что то",NameEndType="Какая то штука | Зачем то нужка"},
                new ModelView.ViewMaterial{Image=@"/Image\image_1.jpeg",MinCol="Минимальное количество 5 шт",
                    Ostatok = "Остаток: 0 шт", Providers="Поставщик: Рога и копыта, СГК, и еще что то",NameEndType="Какая то штука | Зачем то нужка"}
            };*/
            try
            {
                lbContent.ItemsSource = ControllerMaterial.GetViewMaterials();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMenu menu = new WindowMenu();
            menu.Show();
            this.Close();
        }
    }
}

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
using Yffff.View.ModelView;

namespace Yffff.View
{
    /// <summary>
    /// Логика взаимодействия для WindowMaterialSklad.xaml
    /// </summary>
    public partial class WindowMaterialSklad : Window
    {

        private List<View.ModelView.ViewMaterial> content = new List<ModelView.ViewMaterial>();
        public WindowMaterialSklad()
        {
            InitializeComponent();
  
            try
            {
                content = GetContent();
                lbContent.ItemsSource = content;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<ViewMaterial> GetContent()
        {
            try
            {
                return ControllerMaterial.GetViewMaterials();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMenu menu = new WindowMenu();
            menu.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("объект не найден");
        }

        private void DinamicStakBytton(int count)
        {
            int countButton = GetCountButton(count);
        }

        private int GetCountButton(int count)
        {
            if(count % 15==0)
            {
                return count / 15;
            }
            else
            {
                return count / 15 + 1;
            }
            
        }
    }
}

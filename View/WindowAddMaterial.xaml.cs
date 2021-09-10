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

namespace Yffff.View
{
    /// <summary>
    /// Логика взаимодействия для WindowAddMaterial.xaml
    /// </summary>
    public partial class WindowAddMaterial : Window
    {
        public WindowAddMaterial()
        {
            InitializeComponent();
            this.Loaded += WindowAddMaterial_Loaded;
        }

        private void WindowAddMaterial_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Run();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Run()
        {
            cbTypeMaterial.ItemsSource = ContrillerMaterial.GetMaterialComboBox();
            cbSI.ItemsSource = ContrillerSI.GetSIComboBox();
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMaterialSklad windowMaterialSklad = new WindowMaterialSklad();
            windowMaterialSklad.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    
}

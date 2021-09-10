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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Run()
        {
            cbTypeMaterial.ItemsSource = ContrillerMaterial.GetMaterialComboBox();
            cbSI.ItemsSource = ContrillerSI.GetSIComboBox();
            cbImage.ItemsSource = ConterollerImage.GetImages();
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMaterialSklad windowMaterialSklad = new WindowMaterialSklad();
            windowMaterialSklad.Show();
            this.Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Имя не задано");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPrice.Text))
            {
                MessageBox.Show("Укажите цену");
                return;

            }

            try
            {
                double p = Convert.ToDouble(tbPrice.Text);
                if (p < 0)
                {
                    MessageBox.Show("Цена не может быть отрицательной");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Укажите верный формат цены");
            }

            if (string.IsNullOrWhiteSpace(tbPackageCount.Text))
            {
                MessageBox.Show("Укажите кол-во в пачке");
                return;
            }
            try
            {
                int count = Convert.ToInt32(tbPackageCount.Text);
                if (count < 0)
                {
                    MessageBox.Show("Кол-во в пачке не может быть отрицательным");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Укажите правильный формат количества в пачке");
            }



            if (cbSI.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите единицу измерения");
                return;
            }

            try
            {
                if(ControllerMaterial.AddMateril(tbName.Text, tbDescription.Text, tbMinCount.Text, tbPackageCount.Text, tbPrice.Text, cbImage.SelectedItem, cbSI.SelectedItem, cbTypeMaterial.SelectedItem))
                {
                    MessageBox.Show("Обьект добавлен в БД");
                }
                else
                {
                    MessageBox.Show("Объект не   добавлен в  БД");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        




    }
}

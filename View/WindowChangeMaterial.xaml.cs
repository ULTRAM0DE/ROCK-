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
    /// Логика взаимодействия для WindowChangeMaterial.xaml
    /// </summary>
    public partial class WindowChangeMaterial : Window
    {
        public ViewMaterial Material {get;set;}
        public WindowChangeMaterial()
        {
            InitializeComponent();
        }

        public WindowChangeMaterial(ViewMaterial material)
        {
            Material = material;
            tbName.Text = Material.Materials.Name;
            tbMinCount.Text = Material.Materials.MinCount.ToString();
            tbDescription.Text = Material.Materials.Discriptions;
            tbPrice.Text = Material.Materials.Price.ToString();

            try
            {
                cbTypeMaterial.ItemsSource = ContrillerMaterial.GetMaterialComboBox();
                cbSI.ItemsSource = ContrillerSI.GetSIComboBox();
                cbImage.ItemsSource = ConterollerImage.GetImages();

                var sb = (cbSI.ItemsSource as List<string>)
                    .Single(x => x == material.Materials.MaterialTypes.Name);

              

                cbImage.SelectedItem = cbTypeMaterial.Items.IndexOf(sb);

                var sbType = (cbTypeMaterial.ItemsSource as List<string>).Single(x => x == material.Materials.MaterialTypes.Name);

                cbTypeMaterial.SelectedIndex = cbTypeMaterial.Items.IndexOf(sbType);
                cbImage.SelectedIndex = 1;
            }
            catch
            {
                MessageBox.Show("Error bd");
            }
        }
    }
}

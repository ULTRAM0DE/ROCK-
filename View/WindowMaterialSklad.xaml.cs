﻿using System;
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

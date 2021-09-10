
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка возврата на предыдущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMenu menu = new WindowMenu();
            menu.Show();
            this.Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string wanted_path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            wanted_path += @"\Image";

            if(openFileDialog.ShowDialog()==true)
            {
                wanted_path += $@"\{System.IO.Path.GetFileName(openFileDialog.FileName)}";

                File.Copy(openFileDialog.FileName, wanted_path);
            }
        }
    }
}

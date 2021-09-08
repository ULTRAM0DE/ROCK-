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
using Yffff.DB;
using Yffff.View;

namespace Yffff.View
{
    /// <summary>
    /// Логика взаимодействия для WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : Window
    {
        public WindowMenu()
        {
            InitializeComponent();
        }
        public WindowMenu(User user): this()
        {
            Title += $"Вход ({user.Name}) {user.TypeUSer.Name}";
        }
        /// <summary>
        /// Кнопка для возвращения на предыдущий экран
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Кнопка перехода на вкладку 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            View.Window2 window = new Window2();
            window.Show();
            this.Close();
        }
        /// <summary>
        /// Кнопка перехода на вкладку 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            View.Window3 window = new Window3();
            window.Show();
            this.Close();
        }
        /// <summary>
        /// Кнопка перехода на вкладку 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            View.Window4 window = new Window4();
            window.Show();
            this.Close();
        }

        private void btMaterialSklad_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMaterialSklad window = new WindowMaterialSklad();
            window.Show();
            this.Close();
        }
    }
}

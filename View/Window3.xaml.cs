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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
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
    }
}

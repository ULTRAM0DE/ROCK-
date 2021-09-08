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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Yffff.DB;

namespace Yffff
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbName.Text = "Frakiec89";
            tbPassword.Text = "123";
        }

       /// <summary>
       /// Кнопка входа
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = Authentification.AutheAuthentificationUser(tbName.Text, tbPassword.Text);
                View.WindowMenu menu = new View.WindowMenu(user);
                MessageBox.Show("Добро пожаловать пользователь " + user.Name);
                menu.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Пользователь не найден");
            }
          
        }
        /// <summary>
        /// Кнопка закрывающая приложение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClose_Click(object sender, RoutedEventArgs e)
        {          
            this.Close();
        }
        /// <summary>
        /// Аунтификация пользователя
        /// </summary>
        public class Authentification
        {
            public static DB.User AutheAuthentificationUser(string login, string password)
            {
                try
                {
                    DB.dEntities1 entities = new DB.dEntities1();
                    var user = entities.User.Single(x => x.Login==login && x.Password == password);
                    if (user != null)
                    {
                        DB.Logs logs = new DB.Logs() { UserLogin = user.Login, Date = DateTime.Now };
                        entities.Logs.Add(logs);
                        entities.SaveChanges();
                        return user;

                    }
                    else throw new Exception($"пользоатель не найден");
                }
                catch(Exception ex)
                {
                    throw new Exception($"ошибка авторизации \r {ex.Message}");
                }
               

            }
        }
    }
}

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

        private int actualList = 1;
        public int actualMax;

        private List<View.ModelView.ViewMaterial> content = new List<ModelView.ViewMaterial>();
        public WindowMaterialSklad()
        {
            InitializeComponent();
  
            try
            {
                content = GetContent();
                lbContent.ItemsSource = content;
                var s = IntMin(actualList);
                DinamicStakBytton(content.Count);
                actualMax = spButtons.Children.Count - 2;
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

        public void DinamicStakBytton(int count)
        {
            int countButton = GetCountButton( count);
            spButtons.Children.Add(CreateButton("btDown","<<" ,btDown_Click));
           
            for (int i = 0; i < GetCountButton(count); i++)
            {
                spButtons.Children.Add(CreateButton($"btNext{i}", $"{ i+1}", btNext_Click));
            }
            spButtons.Children.Add(CreateButton("btUp", ">>", btUp_Click));


        }

        

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            var but = e.OriginalSource as Button;
            actualList = Convert.ToInt32(but.Content.ToString());
            var s = IntMin(actualList);
            RefreshContent(s, CountContent(s, content.Count));
        }

        private Button CreateButton(string name, string content,  RoutedEventHandler action )
        {
            var b = new Button() { Name = name, Content = content, Margin = new Thickness(5) };
            b.Padding = new Thickness(4);
            b.Background = new SolidColorBrush(Color.FromArgb(255, 255, 193, 193));
            b.HorizontalAlignment = HorizontalAlignment.Center;
            
            b.Click += action;

            return b;
        }


       
            public int GetCountButton(int count)
            {
                if (count % 15 == 0)
                {
                    return count / 15;
                }
                else
                {
                    return count / 15 + 1;
                }

            }
        
        

        private void btDown_Click(object sender, RoutedEventArgs e)
        {
            if(actualList>1)
            {
                actualList--;
                var s = IntMin(actualList);
                RefreshContent(s, CountContent(s,content.Count));
            }
        }


        private void RefreshContent(int start, int end )
        {
            var s = content.GetRange(start, end);
            lbContent.ItemsSource = s;
        }

        private void btUp_Click(object Sender,RoutedEventArgs e)
        {
            if(actualList<actualMax)
            {
                actualList++;
                var s = IntMin(actualList);
                RefreshContent(s, CountContent(s, content.Count));
            }
        }

        public static int IntMin(int list)
        {
            return (list * 15) - 15;
        }

        public static int CountContent(int start,int Maxcount)
        {
            int rez = Maxcount - start;

            if(rez>=15)
            {
                return 15;

            }
            else
            {
                return rez;
            }


        }
    }
}

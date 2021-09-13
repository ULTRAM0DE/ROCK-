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

        private List<string> constenCBSort = new List<string>
        {
             "Без сортировки", "По наименованию (Возрастание)" ,"По наименованию (Убывание)" ,
            "По остатку на складе (Возрастание)", "По остатку на складе (Убывание)",
            "По стоимости (Возрастание)" ,"По стоимости (Убывание)"
        };

        private List<string> constencbFilter = new List<string>
        {
            "Опилки","Дерево","без сортировки"
        };

        

        private List<View.ModelView.ViewMaterial> content = new List<ModelView.ViewMaterial>();
        public WindowMaterialSklad()
        {
            InitializeComponent();
            lbContent.MouseDoubleClick += LbContent_MouseDoubleClick;
           

            try
            {
                content = GetContent();
                Run(content);
                CbSort.ItemsSource = constenCBSort;
                CbSort.SelectedIndex = 0;

                cbFilter.ItemsSource = ContrillerMaterial.GetMaterial();
                cbFilter.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LbContent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var sours = e.OriginalSource as Border;
            if(sours == null)
            {
                return;
            }
            var material = sours.DataContext as View.ModelView.ViewMaterial;
            View.WindowChangeMaterial window = new WindowChangeMaterial(material);
            window.Show();
            this.Close();
        }

        private void Run(List<View.ModelView.ViewMaterial> materials)
        {
            lbContent.ItemsSource = null;
            lbContent.ItemsSource = materials;
            DinamicStakBytton(materials.Count);
            actualMax = spButtons.Children.Count - 2;
            var s = IntMin(actualList);
            RefreshContent(s, CountContent(s, materials.Count), materials);
            labelList.Content = $"лист{actualList}";
            labelItog.Content = $"В базе {GetContent().Count}записей";
            labelRezult.Content = $"Выведено {lbContent.Items.Count}записей";
        }

        private List<ViewMaterial> GetContent()
        {
            try
            {
                return ControllerMaterial.GetViewMaterials();
            }
            catch(Exception ex)
            {
                throw new Exception();
            }

        }
        /// <summary>
        /// кнопка назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMenu menu = new WindowMenu();
            menu.Show();
            this.Close();
        }
        /// <summary>
        /// Вывод результатов поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            var s = content.Where(x => x.Materials.Name.ToUpper().StartsWith(txSearch.Text.ToUpper())).ToList();

            s.AddRange(content.Where(x => x.Providers.ToUpper().Contains(txSearch.Text.ToUpper())));
            s.AddRange(content.Where(x => x.Materials.MaterialTypes.Name.ToUpper().Contains(txSearch.Text.ToUpper())));

            s = s.Distinct().ToList();

            if (s.Count <1)
            {
                MessageBox.Show("Обьект не найден");
                txSearch.Text = string.Empty;
                Run(GetContent());
                return;
            }

            Run(s);

        }
        #region #генерация стекпенел навигации
        public void DinamicStakBytton(int count)
        {
            spButtons.Children.Clear();
            int countButton = GetCountButton( count);
            spButtons.Children.Add(CreateButton("btDown","<<" ,btDown_Click));
           
            for (int i = 0; i < GetCountButton(count); i++)
            {
                spButtons.Children.Add(CreateButton($"btNext{i}", $"{ i+1}", btNext_Click));
            }
            spButtons.Children.Add(CreateButton("btUp", ">>", btUp_Click));


        }

        private Button CreateButton(string name, string content, RoutedEventHandler action)
        {
            var b = new Button() { Name = name, Content = content, Margin = new Thickness(5) };
            b.Padding = new Thickness(4);
            b.Background = new SolidColorBrush(Color.FromArgb(255, 255, 193, 193));
            b.HorizontalAlignment = HorizontalAlignment.Center;

            b.Click += action;

            return b;
        }
        #endregion


        #region #Методы кнопок списка
        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            var but = e.OriginalSource as Button;
            actualList = Convert.ToInt32(but.Content.ToString());
            var s = IntMin(actualList);
            RefreshContent(s, CountContent(s, content.Count),content);
        }
        private void btDown_Click(object sender, RoutedEventArgs e)
        {
            if (actualList > 1)
            {
                actualList--;
                var s = IntMin(actualList);
                RefreshContent(s, CountContent(s, content.Count), content);
            }
        }
        private void btUp_Click(object Sender, RoutedEventArgs e)
        {
            if (actualList < actualMax)
            {
                actualList++;
                var s = IntMin(actualList);
                RefreshContent(s, CountContent(s, content.Count), content);
            }
        }

        private void RefreshContent(int start, int end, List<View.ModelView.ViewMaterial> materials)
        {
            List<View.ModelView.ViewMaterial> s = new List<ViewMaterial>();

            if(materials.Count>end && end>0)
            {
                s.AddRange(materials.GetRange(start, end));
            }
            else
            {
                return;
            }
            
            lbContent.ItemsSource = null;
            lbContent.ItemsSource = s;
            labelList.Content = $"лист{actualList}";
            labelItog.Content = $"В базе {GetContent().Count}записей";
            labelRezult.Content = $"Выведено {lbContent.Items.Count}записей";
        }
        #endregion

        #region #Сортировка,поиск и фильтра
        public void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(CbSort.SelectedItem.ToString())
            {
                case "Без сортировки": Run(content); break;
            case "По наименованию(Возрастание)":SortNameUp(); break;
            case "По наименованию (Убывание)": SortNameDown(); break;
            case "По остатку на складе(Возрастание)": SortOstatokUp(); break;
            case "По  остатку на складе(Убывание)": SortOstatokDown(); break;
            case "По стоимости(Возрастание)": SortPriceUp(); break;
            case "По стоимости (Убывание)": SortPriceDown(); break;
                default:break;
            }
                
        }
        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "Без сортировки": Run(content); break;
                case "Дерево": WoodFilter(); break;
                case "Опилки": OpilkiFilter(); break;
                default:break;
            }
        }

        private void WoodFilter()
        {
            content = content.OrderBy(x => x.count).ToList();
            Run(content);
        }
        private void OpilkiFilter()
        {
            content = content.OrderBy(x => x.count).ToList();
            Run(content);
        }

        private void SortPriceDown()
        {
            content = content.OrderByDescending(x => x.Materials.Price).ToList();
            Run(content);
        }
        private void SortPriceUp()
        {
            content = content.OrderBy(x => x.Materials.Price).ToList();
            Run(content);
        }
        private void SortOstatokDown()
        {
            content = content.OrderByDescending(x => x.count).ToList();
            Run(content);
        }
        private void SortOstatokUp()
        {
            content = content.OrderBy(x => x.count).ToList();
            Run(content);
        }
        private void SortNameUp()
        {
            content = content.OrderBy(x => x.Image).ToList();
            Run(content);
        }
        private void SortNameDown()
        {
            content = content.OrderByDescending(x => x.Image).ToList();
            Run(content);
        }
        #endregion

        public static int IntMin(int list)
        {
            return (list * 15) - 15;
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

        private void btAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            View.WindowAddMaterial windowAddMaterial = new WindowAddMaterial();
            windowAddMaterial.Show();
            this.Close();
        }
    }
}

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

namespace Megatop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Shoes> Shoes;
        public List<Shoes> CurrentShoes;

        public MainWindow()
        {
            Shoes = new List<Shoes>
            {
                new Shoes("Nike","Женская осенняя обувь",1),
                new Shoes("Nike","Мужская летняя обувь",2),
                new Shoes("Adidas","Женская весенняя обувь",3),
                new Shoes("Adidas","Женская летняя обувь",4),
                new Shoes("Puma","Мужская летняя обувь",5),
                new Shoes("Puma","Мужская зимняя обувь",6),
                new Shoes("Reebok","Женская весенняя обувь",7),
                new Shoes("Reebok","Мужская летняя обувь",8),
                new Shoes("Classic","Мужская зимняя обувь",9),
                new Shoes("Classic","Женская осенняя обувь",10),
            };
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text != "")
            {
                string[] searchText = SearchTextBox.Text.ToLower().Split(' ');
                CurrentShoes = new List<Shoes>();
                CurrentShoes = (from s in Shoes
                                where s.Description.ToLower().Split(' ').Distinct().Intersect(searchText).Count() == searchText.Distinct().Count()
                                select s).ToList();
            }
            else
                CurrentShoes = Shoes;
            SearchList.ItemsSource = CurrentShoes;
            if (CurrentShoes.Count() == 0)
            {
                MessageTextBlock.Text = "Нет совпадений";
                AnswerTextBlock.Text = "Объект не найден";
            }
            else
            {
                MessageTextBlock.Text = "Поиск объекта с индексом 8";
                if (CurrentShoes.Any(s => s.Id == 8))
                    AnswerTextBlock.Text = $"Искомый объект в списке {CurrentShoes.FindIndex(s => s.Id == 8) + 1}";
                else
                    AnswerTextBlock.Text = "Объект не найден";
            }
        }
    }
}

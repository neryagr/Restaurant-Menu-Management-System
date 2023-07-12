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

namespace GUI
{
    /// <summary>
    /// Interaction logic for Dish.xaml
    /// </summary>
    public partial class Dish : Window
    {
        public Dish()
        {
            InitializeComponent();
        }

        private void Add_Dish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Add_Dish().ShowDialog();
        }

        private void Remove_Dish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Remove_Dish().ShowDialog();
        }

        private void Update_Dish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Update_Dish().ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new show_dish().Show();
        }
    }
}

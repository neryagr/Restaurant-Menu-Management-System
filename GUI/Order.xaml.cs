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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
        }

        private void Add_Order_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Add_Order().ShowDialog();
        }

        private void Remove_Order_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Remove_Order().ShowDialog();
        }

        private void Update_Order_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Update_Order().ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new show_order().Show();
        }
    }
}

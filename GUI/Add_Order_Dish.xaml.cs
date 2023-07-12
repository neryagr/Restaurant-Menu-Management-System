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
    /// Interaction logic for Add_Order_Dish.xaml
    /// </summary>
    public partial class Add_Order_Dish : Window
    {
        BE.Ordered_Dish od;
        public Add_Order_Dish()
        {
            InitializeComponent();
            od = new BE.Ordered_Dish();
            DataContext = od;
            dish_nameTextBox.ItemsSource = BL.Bl_Factory.get_ibl().Get_All_Dishs().Select(x => x.Name);
            reservation_numberTextBox.ItemsSource = BL.Bl_Factory.get_ibl().Get_All_orders().Select(x => x.Reservation_number);
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.Bl_Factory.get_ibl().add_ordered_dish(od);
                throw (new Exception("success"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ? MessageBoxImage.Information : MessageBoxImage.Error);
            }

        }

        private void main_click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void back_click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Order_Dish().ShowDialog();
        }
    }
}

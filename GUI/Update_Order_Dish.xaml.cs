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
    /// Interaction logic for Update_Order_Dish.xaml
    /// </summary>
    public partial class Update_Order_Dish : Window
    {
        BE.Ordered_Dish od;
        public Update_Order_Dish()
        {
            InitializeComponent();
        }
        private void add_click(object sender, RoutedEventArgs e)
        {
            try{
            if (reservation_numberTextBox.IsEnabled == true)
            {
                reservation_numberTextBox.IsEnabled = false;
                dish_nameTextBox.IsEnabled = false;
                od = BL.Bl_Factory.get_ibl().get_ordered_dish(reservation_numberTextBox.Text+dish_nameTextBox.Text);
                number_of_dishesTextBox.IsEnabled = true;
            }
            else
                BL.Bl_Factory.get_ibl().update_ordered_dish(od);
             throw (new Exception("success"));
            }
                
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ?  MessageBoxImage.Information: MessageBoxImage.Error);
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

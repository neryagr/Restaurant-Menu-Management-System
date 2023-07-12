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
    /// Interaction logic for Update_Order.xaml
    /// </summary>
    public partial class Update_Order : Window
    {
        BE.Order o;
        public Update_Order()
        {
            InitializeComponent();
            this.kusher_levelComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosher_level));
            this.clComboBox.ItemsSource = BL.Bl_Factory.get_ibl().Get_All_clients().Select(x => x.Name);
        }

        private void update(object sender, RoutedEventArgs e)
        {
            try { 
            if (reservation_numberTextBox.IsEnabled == true)
            {
                reservation_numberTextBox.IsEnabled = false;
                o = BL.Bl_Factory.get_ibl().get_order(reservation_numberTextBox.Text);
                DataContext = o;
                dateDatePicker.IsEnabled = true;
                kusher_levelComboBox.IsEnabled = true;
                clComboBox.IsEnabled = true;
                bruanch_numberTextBox.IsEnabled = true;
            }
            else
                BL.Bl_Factory.get_ibl().update_order(o);
 throw (new Exception("success"));
            }
                
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ?  MessageBoxImage.Information: MessageBoxImage.Error);
                }
        }

        private void main(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void order(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Order().Close();
        }
    }
}

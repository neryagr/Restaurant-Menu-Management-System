using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
    /// Interaction logic for Add_Order.xaml
    /// </summary>
    public partial class Add_Order : Window
    {
        BL.IBL b = BL.Bl_Factory.get_ibl();
        BE.Order o;
        public Add_Order()
        {
            InitializeComponent();
            o = new BE.Order();
            this.DataContext = o;
            this.kusher_levelComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosher_level));
            this.clComboBox.ItemsSource = b.Get_All_clients().Select(x => x.Credit_card);
            bruanch_numberTextBox.ItemsSource = BL.Bl_Factory.get_ibl().Get_All_braunches().Select(x => x.Braunch_number);
        }


        private void add_order(object sender, RoutedEventArgs e)
        {
            try
            {
            //    new Thread(() =>
            //              {
                              b.add_order(o);
            //              });
                              throw (new Exception("success"));
            }

            catch (Exception ex)
            {

               MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ?  MessageBoxImage.Information: MessageBoxImage.Error);
            }
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Order().ShowDialog();
        }

        private void grid1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            foreach (var item in grid1.Children)
            {
                if ((item is TextBox))
                    if ((item as TextBox).Text == "" || (item as TextBox).Text == "0")
                    {
                        button2.IsEnabled = false;
                        return;
                    }
            }
            button2.IsEnabled = true;
        }
    }
}

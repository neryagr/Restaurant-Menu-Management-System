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
    /// Interaction logic for Add_Client.xaml
    /// </summary>
    public partial class Add_Client : Window
    {
        BE.Client c;
        public Add_Client()
        {
            InitializeComponent();
            c = new BE.Client();
            DataContext = c;
            button.IsEnabled = false;
        }

        private void click_menu(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void click_client(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Client().ShowDialog();


        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.Bl_Factory.get_ibl().add_client(c);
                this.Close();
                throw (new Exception("success"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ? MessageBoxImage.Error : MessageBoxImage.None);
            }
        }

        private void Grid_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            foreach (var item in grid1.Children)
            {
                if ((item is TextBox))
                    if ((item as TextBox).Text == "" || (item as TextBox).Text == "0")
                    {
                        button.IsEnabled = false;
                        return;
                    }
            }
            button.IsEnabled = true;
        }
    }
}

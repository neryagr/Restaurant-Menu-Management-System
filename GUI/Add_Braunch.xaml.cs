using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Add_Braunch.xaml
    /// </summary>
    public partial class Add_Braunch : Window
    {
        BE.Braunch b;
        public Add_Braunch()
        {
            InitializeComponent();
            b = new BE.Braunch();
            DataContext = b;
            kusher_levelComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosher_level));
            button2.IsEnabled = false;
            
        }
        private void click_menu(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
            BL.Bl_Factory.get_ibl().add_braunch(b);
            this.Close();
            throw (new Exception("success"));
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ?  MessageBoxImage.Information: MessageBoxImage.Error);
            }
        }

        private void click_bruanch(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Bruanch().ShowDialog();

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

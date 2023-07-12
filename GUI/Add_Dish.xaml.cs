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
    /// Interaction logic for Add_Dish.xaml
    /// </summary>
    public partial class Add_Dish : Window
    {
        BE.Dish d;
        

        public Add_Dish()
        {
            InitializeComponent();
            kusher_levelComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosher_level));
            sizeComboBox.ItemsSource = Enum.GetValues(typeof(BE.DISH_SIZE));
            d = new BE.Dish();
            DataContext = d;
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {

            BL.Bl_Factory.get_ibl().add_dish(d);
            throw (new Exception("success"));
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ?  MessageBoxImage.Information: MessageBoxImage.Error);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Dish().ShowDialog();
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

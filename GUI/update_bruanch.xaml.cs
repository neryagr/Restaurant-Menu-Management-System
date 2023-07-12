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
    /// Interaction logic for Add_Braunch.xaml
    /// </summary>
    public partial class update_bruanch : Window
    {
        BE.Braunch b;
        public update_bruanch()
        {
            InitializeComponent();
            kusher_levelComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosher_level));
            var v = BL.Bl_Factory.get_ibl().Get_All_braunches();
            if (v.Count() == 0)
            {
                MessageBox.Show("you have no brunches to uptade");
                this.Close();
                new Bruanch().ShowDialog();

            }
            braunch_numberTextBox.ItemsSource = v.Select(x => x.Braunch_number);

        }
        private void click_menu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a;
                if (!int.TryParse(braunch_numberTextBox.Text, out a))
                    throw new Exception("you must enter number");
                if (braunch_numberTextBox.IsEnabled == true)
                {
                    braunch_numberTextBox.IsEnabled = false;
                    b = BL.Bl_Factory.get_ibl().get_braunch(braunch_numberTextBox.Text);
                    DataContext = b;
                    streetTextBox.DataContext = b.Address;
                    cityTextBox.DataContext = b.Address;
                    numTextBox.DataContext = b.Address;
                    braunch_responsibleComboBox.IsEnabled = true;
                    kusher_levelComboBox.IsEnabled = true;
                   Delivers_availableTextBox.IsEnabled = true;
                    streetTextBox.IsEnabled = true;
                    numTextBox.IsEnabled = true;
                    cityTextBox.IsEnabled = true;
                    phone_numberTextBox.IsEnabled = true;
                    opening_hourTextBox.IsEnabled = true;
                    closing_hourTextBox.IsEnabled = true;
                }
                else

                    BL.Bl_Factory.get_ibl().update_braunch(b);
                throw (new Exception("success"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ?  MessageBoxImage.Information: MessageBoxImage.Error);
            }

        }

        private void click_bruanch(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Bruanch().ShowDialog();
        }


    }
}

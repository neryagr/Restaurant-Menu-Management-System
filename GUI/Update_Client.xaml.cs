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
    /// Interaction logic for Update_Client.xaml
    /// </summary>
    public partial class Update_Client : Window
    {
        BE.Client c;
        public Update_Client()
        {
            InitializeComponent();
            var v = BL.Bl_Factory.get_ibl().Get_All_clients();
            if (v.Count()==0)
            { 
                MessageBox.Show("you have no clients to uptade");
                this.Close();
                new Client().ShowDialog();
            }
            credit_cardTextBox.ItemsSource = v.Select(x => x.Credit_card);
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

        private void update_click(object sender, RoutedEventArgs e)
        {
            try{

            
            if (credit_cardTextBox.IsEnabled == true)
            {
                credit_cardTextBox.IsEnabled = false;
                c = BL.Bl_Factory.get_ibl().get_client(credit_cardTextBox.Text);
                DataContext = c;
                streetTextBox.DataContext = c.Address;
                    cityTextBox.DataContext = c.Address;
                    numTextBox.DataContext = c.Address;
                streetTextBox.IsEnabled = true;
                ageTextBox.IsEnabled = true;
                cityTextBox.IsEnabled = true;
                numTextBox.IsEnabled = true;
                nameTextBox.IsEnabled = true;
                overdraftTextBox.IsEnabled = true;
            }
            
            else 
                BL.Bl_Factory.get_ibl().update_client(c);

            throw (new Exception("successs"));
            }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ?  MessageBoxImage.Information: MessageBoxImage.Error);
                }
        }
        }
    }


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
    /// Interaction logic for Remove_Client.xaml
    /// </summary>
    public partial class Remove_Client : Window
    {
        public Remove_Client()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
 if( ClientID.Text.Count(x=>(int)x<=48||(int)x>=57)>0)
                {
                    throw new Exception("You have to use numbers");
                }
                BL.Bl_Factory.get_ibl().remove_client(ClientID.Text);
                throw (new Exception("success"));
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ?  MessageBoxImage.Information: MessageBoxImage.Error);
            }
               

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Client().ShowDialog();
        }
    }
}

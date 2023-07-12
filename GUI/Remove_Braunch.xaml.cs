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
    /// Interaction logic for Remove_Braunch.xaml
    /// </summary>
    public partial class Remove_Braunch : Window
    {
        public Remove_Braunch()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                if (!int.TryParse(BranchNumber.Text, out num))
                {
                    throw new Exception("you have to use numbers");
                }
                BL.Bl_Factory.get_ibl().remove_braunch(BranchNumber.Text);
                throw (new Exception("success"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Message == "success" ? "Error" : "good ", MessageBoxButton.OK, ex.Message == "success" ? MessageBoxImage.Error : MessageBoxImage.Hand);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
    
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Bruanch().ShowDialog();
        }
    }
}

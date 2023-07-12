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
    /// Interaction logic for Update_Dish.xaml
    /// </summary>
    public partial class Update_Dish : Window
    {
        BE.Dish d;
        public Update_Dish()
        {
            InitializeComponent();
            sizeComboBox.ItemsSource= Enum.GetValues(typeof(BE.DISH_SIZE));
            kusher_levelComboBox.ItemsSource= Enum.GetValues(typeof(BE.kosher_level));
            var v = BL.Bl_Factory.get_ibl().Get_All_Dishs();
            if (v.Count() == 0)
            {
                MessageBox.Show("you have no Dishes to uptade");
                this.Close();
                new Dish().ShowDialog();
                
            }
           nameTextBox.ItemsSource = v.Select(x => x.Name);
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

        private void add_click(object sender, RoutedEventArgs e)
        {
            try{
            if (nameTextBox.IsEnabled == true)
            {
                nameTextBox.IsEnabled = false;
                d = BL.Bl_Factory.get_ibl().get_dish(nameTextBox.Text);
                DataContext = d;
                priceTextBox.IsEnabled = true;
                kusher_levelComboBox.IsEnabled = true;
                sizeComboBox.IsEnabled = true;
            }
            else
                BL.Bl_Factory.get_ibl().update_dish(d);
            throw (new Exception("success"));
            }
                
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, ex.Message == "success" ? "Good " : "Error", MessageBoxButton.OK, ex.Message == "success" ?  MessageBoxImage.Information: MessageBoxImage.Error);
                }
        }
        }
    }


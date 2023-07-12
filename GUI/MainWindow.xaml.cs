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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;
using System.Collections;
using System.Reflection;
using System.Xml.Linq;

namespace GUI
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = Bl_Factory.get_ibl();
        public MainWindow()
        {
            InitializeComponent();
            bl.open();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource braunchViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("braunchViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // braunchViewSource.Source = [generic data source]
        }
        private void Brunch_Click(object sender, RoutedEventArgs e)
        {
      
             new Bruanch().ShowDialog();

        }

        private void Client_Click(object sender, RoutedEventArgs e)
        { 
           new Client().ShowDialog();

        }

        private void Dish_Click(object sender, RoutedEventArgs e)
        {
           
            new Dish().ShowDialog();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            
            new Order().ShowDialog();
        }

        private void Order_Dish_click(object sender, RoutedEventArgs e)
        {
           
            new Order_Dish().ShowDialog();
        }

        private void General_Click(object sender, RoutedEventArgs e)
        {
            
            new General().ShowDialog();
        }
    }
}

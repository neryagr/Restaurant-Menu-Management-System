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
    /// Interaction logic for Bruanch.xaml
    /// </summary>
    public partial class Bruanch : Window
    {
        public Bruanch()
        {
            InitializeComponent();
        }
        private void Add_braunch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Add_Braunch().ShowDialog();
        }

        private void Remove_Braunch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Remove_Braunch().ShowDialog();
        }

        private void Update_Braunch_Click(object sender, RoutedEventArgs e)
        {
            new update_bruanch().ShowDialog();
            this.Close();
            
        }

        private void show_all_click(object sender, RoutedEventArgs e)
        {
            new show_braunch().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

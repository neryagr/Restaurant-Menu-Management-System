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
    /// Interaction logic for General.xaml
    /// </summary>
    public partial class General : Window
    {
        BL.IBL bl = BL.Bl_Factory.get_ibl();
        public General()
        {
            InitializeComponent();
            profit_switch.Visibility = Visibility.Hidden;
            string[] s = new string[] { "dish", "braunch", "client","Time" };
            this.order.ItemsSource = bl.Get_All_orders().Select(x => x.Reservation_number);
            this.choose.ItemsSource = s;
            this.most_profit.ItemsSource = s;
            Time.ItemsSource=Enum.GetValues(typeof(BE.choise));
            Time.Visibility = Visibility.Hidden;
        }

        private void choose_LostFocus1(object sender, RoutedEventArgs e)
        {
            if (profit_switch.Text != "")
                switch (choose.Text)
                {
                    case "dish":
                        profit_of.Text = bl.get_profit_dish(this.profit_switch.Text).ToString();
                        break;
                    case "braunch":
                        profit_of.Text = bl.get_profit_bruanch(this.profit_switch.Text).ToString();
                        break;
                    case "client":
                        profit_of.Text = bl.get_profit_client(this.profit_switch.Text).ToString();
                        break;
                    default:
                        this.profit_switch.Visibility = Visibility.Hidden;
                        break;

                }
        }
        private void choose_LostFocus(object sender, RoutedEventArgs e)
        {
            this.profit_switch.Visibility = Visibility.Visible;
            switch (choose.Text)
            {
                case "dish":
                    profit_switch.ItemsSource = bl.Get_All_Dishs().Select(x => x.Name);
                    break;
                case "braunch":
                    profit_switch.ItemsSource = bl.Get_All_braunches().Select(x => x.Braunch_number);
                    break;
                case "client":
                    profit_switch.ItemsSource = bl.Get_All_clients().Select(x => x.Credit_card);
                    break;
                default:
                    this.profit_switch.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void order_LostFocus(object sender, RoutedEventArgs e)
        {
            if (order.Text != "")
                calculate_order.Text = bl.calculate_order(order.Text).ToString();
        }

        private void most_profit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (most_profit.Text != "")
            {
                userc.Children.Clear();
                switch (most_profit.Text)
                {
                    case "dish":
                        BE.Dish d = bl.most_profitable_dish();
                        userc.Children.Add(new show_dish_(d));
                        mosttext.Text = bl.get_profit_dish(d.Name).ToString();
                        break;
                    case "braunch":
                        BE.Braunch b = bl.most_profitable_bruanch();
                        userc.Children.Add(new show_braunch_(b));
                        mosttext.Text = bl.get_profit_client(b.Braunch_number).ToString();
                        break;
                    case "client":
                        BE.Client c = bl.most_profitable_client();
                        userc.Children.Add(new show_client_(c));
                        mosttext.Text = bl.get_profit_client(c.Credit_card).ToString();
                        break;
                    case "Time":
                        Time.Visibility = Visibility.Visible;
                        break;

                    default:
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Time_LostFocus(object sender, RoutedEventArgs e)
        {
            if(Time.Text!="")
            {
                userc.Children.Clear();
            switch (most_profit.Text)
            {
                case "Time":
                    mosttext.Text = bl.most_profitable_time((BE.choise)Time.SelectedItem);
                        break;
                default:
                    break;
            }
            }
        }
    }
}

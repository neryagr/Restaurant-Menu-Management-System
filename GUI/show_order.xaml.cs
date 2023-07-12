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
    /// Interaction logic for show_order.xaml
    /// </summary>
    public partial class show_order : Window
    {
        public show_order()
        {
            InitializeComponent();
            StackPanel[] arr = new StackPanel[]{ s, s1, s2, s3 };
            int i = 0;
            
            foreach (var item in BL.Bl_Factory.get_ibl().Get_All_orders() )
            {
                arr[i++ % 4].Children.Add(new show_order_(item));

            }
        }
    }
}

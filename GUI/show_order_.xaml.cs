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

namespace GUI
{
    /// <summary>
    /// Interaction logic for show_order_.xaml
    /// </summary>
    public partial class show_order_ : UserControl
    {
        public show_order_(BE.Order o)
        {
            InitializeComponent();
            DataContext = o;
        }
    }
}

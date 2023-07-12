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
    /// Interaction logic for show_client_.xaml
    /// </summary>
    public partial class show_client_ : UserControl
    {
        public show_client_(BE.Client c)
        {
            InitializeComponent();
            DataContext = c;
        }
    }
}

﻿using System;
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
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Add_Client_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Add_Client().ShowDialog();
        }

        private void Remove_Client_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Remove_Client().ShowDialog();
        }

        private void Update_Client_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Update_Client().ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new show_client().Show();
        }
    }
}

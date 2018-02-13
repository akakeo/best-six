﻿using Database;
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

namespace bestsixapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void RoomClick(object sender, RoutedEventArgs e)
        {
            RoomMake roomWindow = new RoomMake();
            roomWindow.Show();
            
        }

        private void CustomerClick(object sender, RoutedEventArgs e)
        {
            Check checkWindow = new Check();
            checkWindow.Show();
        }

        private void CheckOutClick(object sender, RoutedEventArgs e)
        {
            CheckOut checkOutWindow = new CheckOut();
            checkOutWindow.Show();
        }


    }

}


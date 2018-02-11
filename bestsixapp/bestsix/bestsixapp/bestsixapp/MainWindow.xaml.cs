using Database;
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
            this.Closed += new EventHandler(MainWindow_Closed);
        }

        private void RoomClick(object sender, RoutedEventArgs e)
        {
            RoomMake roomWindow = new RoomMake();
            roomWindow.ShowDialog();
            
        }

        private void CustomerClick(object sender, RoutedEventArgs e)
        {
            Check checkWindow = new Check();
            checkWindow.ShowDialog();
        }

        protected void MainWindow_Closed(object sender, EventArgs args)
        {

            App.Current.Shutdown();

      
        }


    }

}


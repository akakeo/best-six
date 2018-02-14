using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for RoomInfo.xaml
    /// </summary>
    public partial class RoomInfo : Window
    {
        public RoomInfo()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                //add data to database
                dbContext.Rooms.Add(new Room {RoomNo = Int32.Parse(TextBoxRoomNo.Text), BedType = TextBoxBedType.Text,
                    NoOfBeds = Int32.Parse(TextBoxNoOfBeds.Text), Price = Double.Parse(TextBoxPrice.Text), Smoking = TextBoxSmoking.Text  });
                //save changes
                dbContext.SaveChanges();
                //close screen
                Close();
            }
        }
        //method for cancel
        public void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

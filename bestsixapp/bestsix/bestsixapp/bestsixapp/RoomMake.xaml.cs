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

namespace bestsixapp
{
    /// <summary>
    /// Interaction logic for RoomMake.xaml
    /// </summary>
    public partial class RoomMake : Window
    {
        private bool isEdit = false;
        
        public RoomMake()
        {
            InitializeComponent();
            
        }

        private void CreateRoomClick(object sender, RoutedEventArgs e)
        {
            //create room object
            Room room = new Room(this.Width,this.Height);
            var rect = (Rectangle)room.makeRoom();
            rect.MouseLeftButtonDown += rect_MouseLeftButtonDown;
            rect.MouseLeftButtonUp += rect_MouseLeftButtonUp;
            rect.MouseMove += rect_MouseMove;
            RoomCanvas.Children.Add(rect);
        }
        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rect = (Rectangle)sender;
            rect.CaptureMouse();
        }


        private void rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }
        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            var rect = (Rectangle)sender;

            if (!rect.IsMouseCaptured) return;

            // get the position of the mouse relative to the Canvas
            var mousePos = e.GetPosition(RoomCanvas);

            // center the rect on the mouse
            double left = mousePos.X - (rect.ActualWidth / 2);
            double top = mousePos.Y - (rect.ActualHeight / 2);
            if (isEdit)
            {
                if (left < 0) left = 0;
                Canvas.SetLeft(rect, left);

                Canvas.SetTop(rect, top);
            }
        }

        private void EditRoomClick(object sender, RoutedEventArgs e)
        {
            if (EditRoomButton.Content.ToString() == "Edit Rooms")
            {

                EditRoomButton.Padding = new Thickness(16.7);
                EditRoomButton.Content = "Finish";
                isEdit = true;
            }
            else
            {
                EditRoomButton.Content = "Edit Rooms";
                EditRoomButton.Padding = new Thickness(2);
                isEdit = false;
            }
        }
           
    }
}


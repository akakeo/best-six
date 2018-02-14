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
        RoomData room;
        private bool isEdit = false;
        public RoomMake()
        {
            InitializeComponent();

        }

        private void CreateRoomClick(object sender, RoutedEventArgs e)
        {
            //create room object
            if (isEdit)
            {
                EditRoomInfo();
            }
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
            {//boundary for left side
                if (left < 0) left = 0;
                //boundary for right side
                if (left > this.ActualWidth - rect.ActualWidth * 1.16) left = this.ActualWidth - rect.ActualWidth * 1.16;
                //boundary for top
                if (top < 0) top = 0;
                //boundary for bottom
                if (top > this.ActualHeight - rect.ActualHeight * 2.58) top = this.ActualHeight - rect.ActualHeight * 2.58;
                Canvas.SetLeft(rect, left);
                Canvas.SetTop(rect, top);
                room.SetLeft(Canvas.GetLeft(rect));
                room.SetTop(Canvas.GetTop(rect));
            }

        }

        private void EditRoomClick(object sender, RoutedEventArgs e)
        {
            if (EditRoomButton.Content.ToString() == "Edit Rooms")
            {
                //Change button to finish and enable edit
                EditRoomButton.Padding = new Thickness(16.7);
                EditRoomButton.Content = "Finish";
                isEdit = true;
            }
            else
            {
                //change button to edit rooms and disable edit
                EditRoomButton.Content = "Edit Rooms";
                EditRoomButton.Padding = new Thickness(2);
                isEdit = false;
            }
        }

        private void EditRoomInfo()
        {
            RoomInfo newRoomInfo = new RoomInfo();
            newRoomInfo.Show();
            newRoomInfo.SaveButton.Click += SaveClickEventHandler;
        }


        private void SaveClickEventHandler(object sender, RoutedEventArgs e) => CreateRoom(); //call cancel method

        public void CreateRoom()
        {
            if (isEdit)
            {
                room = new RoomData();
                //cast object
                var rect = (Rectangle)room.makeRoom();
                //tract mouse events
                rect.MouseLeftButtonDown += rect_MouseLeftButtonDown;
                rect.MouseLeftButtonUp += rect_MouseLeftButtonUp;
                rect.MouseMove += rect_MouseMove;
                //add room object to room list
                //add object to canvas
                RoomCanvas.Children.Add(rect);
                room.SetLeft(Canvas.GetLeft(rect));
                room.SetTop(Canvas.GetTop(rect));
                Console.WriteLine(Canvas.GetLeft(rect));
                Console.WriteLine(Canvas.GetTop(rect));
            }
        }
    }
}


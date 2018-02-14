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
        private bool isCancelled = false;
        List<RoomData> Rooms = new List<RoomData>();
        public RoomMake()
        {
            InitializeComponent();
            
        }

        private void CreateRoomClick(object sender, RoutedEventArgs e)
        {
            //create room object
            if (isEdit)
            {
                if (!isCancelled)
                {
                    //create object roomData
                    RoomData room = new RoomData();
                    //cast object
                    var rect = (Rectangle)room.makeRoom();
                    //tract mouse events
                    rect.MouseLeftButtonDown += rect_MouseLeftButtonDown;
                    rect.MouseLeftButtonUp += rect_MouseLeftButtonUp;        
                    rect.MouseMove += rect_MouseMove;
                    EditRoomInfo();
                    //add room object to room list
                    Rooms.Add(room);
                    //add object to canvas
                    RoomCanvas.Children.Add(rect);
                    isCancelled = false;
                    
                }
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
            {
                if (left < 0) left = 0;
                if (left > this.ActualWidth - rect.ActualWidth*1.16) left = this.ActualWidth - rect.ActualWidth*1.16;
                if (top < 0) top = 0;
                if (top > this.ActualHeight - rect.ActualHeight*2.58) top = this.ActualHeight - rect.ActualHeight*2.58;
                Canvas.SetLeft(rect, left);
                Canvas.SetTop(rect, top);
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
            newRoomInfo.ShowDialog();
            newRoomInfo.CancelButton.Click += ClickEventHandler;
        }
        private void ClickEventHandler(object sender, RoutedEventArgs e) => setCancel(); //call cancel method

        public void setCancel() =>
            //set bool cancel to true
            isCancelled = true;
    }
}


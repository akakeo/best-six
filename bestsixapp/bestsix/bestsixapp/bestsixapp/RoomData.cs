using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing;

namespace bestsixapp
{
    class RoomData
    {
        /*
        int RoomNo, NoOfBeds;*/
        double Left, Top, Price;
        /*
        string BedType,Checkin,Checkout,Legend;
       */
        double width, height;
        Rectangle rect;

        public Rectangle Rect { get => rect; set => rect = value; }

        public RoomData()
        {
            width = 115; // width of rect
            height = 65; //height of rect
        }
        //create rectangle to display room
        public object makeRoom()
        {
            rect = new Rectangle
            {
                Fill = new SolidColorBrush(Colors.Green),
                Stroke = new SolidColorBrush(Colors.Black),
                Width = width,
                Height = height,
                StrokeThickness = 2
            };
            return Rect;
        }

        public void drawRoom()
        {
            Rectangle rect = new Rectangle
            {
                Fill = new SolidColorBrush(Colors.Green),
                Stroke = new SolidColorBrush(Colors.Black),
                Width = width,
                Height = height,
                StrokeThickness = 2
            };
        }
        
        public void Occupied()
        {    
            rect.Fill = new SolidColorBrush(Colors.Red);
        }

        public void Empty()
        {
            rect.Fill = new SolidColorBrush(Colors.LightGreen);
        }
        
        public void needCleaning()
        {
            rect.Fill = new SolidColorBrush(Colors.Yellow);
        }

        public void SetLeft(double left) => Left = left;

        public void SetTop(double top) => Top = top;

       
    }
}

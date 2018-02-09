using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace bestsixapp
{
    class Room
    {
        int RoomNo, NoOfBeds;
        double Left, Top, Price;
        string BedType,Checkin,Checkout,Legend;
        double width, height;

        public Room(double Width, double Height)
        {
            this.width = Width/10;
            this.height = Height/10;
           
        }
        //create rectangle to display room
        public object makeRoom()
        {
            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(Colors.AntiqueWhite);
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Width = width;
            rect.Height = height;
            rect.StrokeThickness = 2;
            return rect;
        }
      
   
        
    }
}

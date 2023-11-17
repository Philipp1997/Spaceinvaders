using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Spaceinvaders
{
    internal class PewPew : SpaceObject
    {
        internal void Designe()
        {
            PointCollection points = new PointCollection();
            shape.Fill = Brushes.Red;

            for (int i = 0; i <20; i++) 
            {
                double radius = 5;
                double winkel = 2 * Math.PI * i / 20; // Formel für den Winkel
                double x = radius * Math.Cos(winkel);
                double y = radius * Math.Sin(winkel);
                points.Add(new Point(x, y));
            }
            shape.Points = points;
        }
        internal bool BorderCol(int i)
        {
            if (X >= Global.SpaceCanvas.ActualWidth)
            {
                Ship.pewpewList.RemoveAt(i);
                return true;
            }
            return false;
        }
        internal PewPew() 
        {
            Alive = true;
            X = Global.Player_X + 45; 
            Y = Global.Player_Y + 10;
            X_Vector = 15;
        }
    }
}

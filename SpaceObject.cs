using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Spaceinvaders
{
    internal class SpaceObject
    {
        public Polygon shape { get; set; } = new Polygon();
        protected Polygon Shape { get { return shape; } set { shape = value; } }
        internal double X { get; set; }
        internal double Y { get; set; }
        internal double X_Vector { get; set; }
        internal double Y_Vector { get; set; }
        internal bool Alive { get; set; } // alle verweise löschen und diese zeile auch



        internal void Show()
        {
                Canvas.SetLeft(shape, X);
                Canvas.SetTop(shape, Y);
                Global.SpaceCanvas.Children.Add(shape);
        }

        internal void RemoveFromCanvas()
        {
            Global.SpaceCanvas.Children.Remove(shape);
        }
        
        internal void Move()
        {
            X = X + X_Vector; 
            Y = Y+Y_Vector;
        }



    }

}

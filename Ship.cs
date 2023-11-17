using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;

namespace Spaceinvaders
{
    internal class Ship : SpaceObject
    {
        internal static List<PewPew> pewpewList = new List<PewPew>();
        internal void Designe()
        {
            PointCollection myPointCollection = new PointCollection();
            shape.Fill = Brushes.MintCream;

            Point Point0 = new Point(0, 0);
            Point Point1 = new Point(50, 10);
            Point Point2 = new Point(0, 20);
            Point Point3 = new Point(10, 10);

            myPointCollection.Add(Point0);
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);

            shape.Points = myPointCollection;
        }
        //internal void PewPewTick()
        //{

        //    foreach (PewPew item in pewpewList)
        //    {
        //        item.RemoveFromCanvas();
        //        item.Move();
        //        item.Show();
        //    }
        //}
        internal Ship()
        {

        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Media;

namespace Spaceinvaders
{
    internal class PowerUp : SpaceObject
    {
        internal static List<PowerUp> powerUpList = new List<PowerUp>();
        internal void Designe()
        {
            PointCollection myPointCollection = new PointCollection();
            shape.Fill = Brushes.RosyBrown;

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
        internal void PowerUpSpawnTimer()
        {
            if (Global.PowerUpTimer >0)
            {
                Global.PowerUpTimer--;
            }
            else
            {
                powerUpList.Add(new PowerUp());
                powerUpList[powerUpList.Count - 1].Designe();
                Global.PowerUpTimer = 30;
            }
        }
        //internal void PowerUpTick()
        //{
        //    foreach (PowerUp item in powerUpList)
        //    {
        //        item.RemoveFromCanvas();
        //        item.Move();
        //        item.Show();
        //    }
        //}
        internal bool BorderCol(int i)
        {
            if (X <= 0)
            {
                powerUpList.RemoveAt(i);
                return true;
            }
            return false;
        }
        internal PowerUp()
        {
            int Lane = Global.rnd.Next(8);
            X_Vector = Global.rnd.Next(-40,-6);
            Alive = true;
            X = Global.SpaceCanvas.ActualWidth;
            Y = Global.Lanes[Lane];
        }
    }
}

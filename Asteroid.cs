using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Spaceinvaders
{
    internal class Asteroid : SpaceObject
    {
        internal static int varRadius;
        internal static List<Asteroid> asteroidList = new List<Asteroid>();

        public void Designe()
        {
            PointCollection myPointCollection = new PointCollection();
            shape.Fill = Brushes.LightGray;

            for (int i = 0; i < 20; i++)
            {
                double angle = 2 * Math.PI * i / 20; //Winkelberechnung
                double radius = 25;
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);

                myPointCollection.Add(new Point(x, y));
            }

            shape.Points = myPointCollection;
        }
        internal bool BorderCol(int i)
        {
            if (X <= 0)
            {
                asteroidList.RemoveAt(i);
                return true;
            }
            return false;
        }
        internal void PewPewCol() 
        {
            if(Asteroid.asteroidList.Count > 0 && Ship.pewpewList.Count > 0)
            {
                var pewHitbox = new EllipseGeometry();
                pewHitbox.RadiusX = 5;
                pewHitbox.RadiusY = 5;

                var astHitbox = new EllipseGeometry();
                astHitbox.RadiusX = Global.LaneSize / 2;
                astHitbox.RadiusY = Global.LaneSize / 2;

                

                for (int i = 0; i < asteroidList.Count; i++)
                {
                    astHitbox.Center = new Point(asteroidList[i].X, asteroidList[i].Y);


                    for (int j = 0; j < Ship.pewpewList.Count; j++)
                    {
                        pewHitbox.Center = new Point(Ship.pewpewList[j].X, Ship.pewpewList[j].Y);
                        var hit = pewHitbox.FillContainsWithDetail(astHitbox);

                        if (hit == IntersectionDetail.Intersects)
                        {
                            asteroidList[i].RemoveFromCanvas();
                            Ship.pewpewList[j].RemoveFromCanvas();
                            asteroidList.RemoveAt(i);
                            Ship.pewpewList.RemoveAt(j);
                        }
                    }
                }
            }
        }
        internal void AsteroidSpawnTimer()
        {
            if (Global.AsteroidTimer > 0)
            {
                Global.AsteroidTimer--;
            }
            else
            {
                asteroidList.Add(new Asteroid());
                asteroidList[asteroidList.Count - 1].Designe();
                Global.AsteroidTimer = 30;
            }
        }

        //internal void AsteroidTick()
        //{
        //    AsteroidSpawnTimer();
        //    foreach (Asteroid item in asteroidList)
        //    {
        //        item.RemoveFromCanvas();
        //        item.Move();
        //        item.Show();
        //    }
        //}
        internal Asteroid()
        {
            Alive = true;
            int Lane = Global.rnd.Next(0,8);
            varRadius = Global.LaneSize / 2;
            X_Vector = Global.rnd.Next(-20,-6);
            X = Global.SpaceCanvas.ActualWidth;
            Y = Global.Lanes[Lane];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Spaceinvaders
{
    internal static class GameManager
    {
        private static DispatcherTimer timer = new DispatcherTimer();
        private static Player testShip = new Player();
        private static Asteroid testAsteroid = new Asteroid();
        private static PewPew testPewPew = new PewPew();
        private static PowerUp testPowerUp = new PowerUp();

        public static void Initialize()
        {
            //Hinzufügen der Lanes für die Kometen und Zuweisen der LaneSize
            Global.LaneSize = Convert.ToInt32(Global.SpaceCanvas.ActualHeight / 8);
            for (int i = 0; i<8;i++)
            {
                Global.Lanes.Add(Global.LaneSize * (i + 1));
            }

            //Timer erstellen und starten
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(0.03);
            timer.Start();


            testShip.Designe();
            testAsteroid.Designe();
            testPowerUp.Designe();
            testPewPew.Designe();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            PewPewCooldown();
            testAsteroid.AsteroidSpawnTimer();
            testPowerUp.PowerUpSpawnTimer();

            testShip.RemoveFromCanvas();
            testShip.SetMovingDirection();
            testShip.BorderCol();
            testShip.Move();
            testShip.Show();

            testAsteroid.PewPewCol();
            ItemListen();

        }
        private static void ItemListen()
        {
            for (int i = 0; i < Asteroid.asteroidList.Count; i++)
            {

                Asteroid.asteroidList[i].RemoveFromCanvas();
                if (Asteroid.asteroidList[i].BorderCol(i) == false)
                {
                    Asteroid.asteroidList[i].Move();
                    Asteroid.asteroidList[i].Show();
                }
                else if (false)
                {
                    
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < PowerUp.powerUpList.Count; i++)
            {
                PowerUp.powerUpList[i].RemoveFromCanvas();
                if (PowerUp.powerUpList[i].BorderCol(i) == false)
                {
                    PowerUp.powerUpList[i].Move();
                    PowerUp.powerUpList[i].Show();
                }
                else
                {
                    i--;
                }


            }

            for (int i = 0; i < Ship.pewpewList.Count; i++)
            {
                
                Ship.pewpewList[i].RemoveFromCanvas();
                if (Ship.pewpewList[i].BorderCol(i) == false)
                {
                    Ship.pewpewList[i].Move();
                    Ship.pewpewList[i].Show();
                }
                else
                {
                    i--;
                }
                
            }


        }
        private static void PewPewCooldown()
        {
            if (Keyboard.IsKeyDown(Key.Space) && Global.PewPewTimer == 0)
            {
                testShip.Laser();
            }

            else if (Global.PewPewTimer != 0)
            {
                Global.PewPewTimer--;
            }
        }

    }
}

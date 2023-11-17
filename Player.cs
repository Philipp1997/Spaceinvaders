using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;


namespace Spaceinvaders
{
    internal class Player : Ship
    {
        internal void SetMovingDirection()
        {
            //Links-Unten
            if ((Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left)) && (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down)))
            {
                X_Vector = -10 * Math.Cos(315);
                Y_Vector = 10 * Math.Sin(315);
            }
            // Links-Oben
            else if ((Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left)) && (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up)))
            {
                X_Vector = -10 * Math.Cos(45);
                Y_Vector = -10 * Math.Sin(45);
            }
            // Rechts-Unten
            else if ((Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right)) && (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down)))
            {
                X_Vector = 10 * Math.Cos(315);
                Y_Vector = 10 * Math.Sin(315);
            }
            // Rechts-Oben
            else if ((Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right)) && (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up)))
            {
                X_Vector = 10 * Math.Cos(45);
                Y_Vector = -10 * Math.Sin(45);
            }
            // Links
            else if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
            {
                X_Vector = -10;
                Y_Vector = 0;
            }
            // Rechts
            else if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
            {
                X_Vector = 10;
                Y_Vector = 0;
            }
            // Unten
            else if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))
            {
                X_Vector = 0;
                Y_Vector = 10;
            }
            // Oben
            else if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))
            {
                X_Vector = 0;
                Y_Vector = -10;
            }
        }
        internal void Laser()
        {
            Global.Player_X = X;
            Global.Player_Y = Y;
            pewpewList.Add(new PewPew());
            pewpewList[pewpewList.Count - 1].Designe();
            Global.PewPewTimer = 1;
        }
        internal void BorderCol()
        {
            if (X <= 0 && X_Vector < 0)
            {
                X_Vector = 0;
            }
            if (X >= Global.SpaceCanvas.ActualWidth - 50 && X_Vector > 0)
            {
                X_Vector = 0;
            }
            if (Y <= 0 && Y_Vector < 0)
            {
                Y_Vector = 0;
            }
            if (Y >= Global.SpaceCanvas.ActualHeight - 30 && Y_Vector > 0)
            {
                Y_Vector = 0;
            }
        }
        internal Player()
        {
            Alive = true;
        }

        
        

    }
}

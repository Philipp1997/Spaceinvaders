using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Spaceinvaders
{
    static class Global
    {
        internal static Canvas SpaceCanvas { get; set; }
        internal static Key LastButton { get; set; }
        internal static List<int> Lanes { get; set; }
        internal static Random rnd = new Random();
        internal static int LaneSize = 0;
        internal static int AsteroidTimer = 30;
        internal static int PowerUpTimer = 30;
        internal static int PewPewTimer = 20;
        internal static double Player_X;
        internal static double Player_Y;

        static Global()
        {
            Lanes = new List<int>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusTestHighScore
{
    class map
    {
        public map()
        {
            Console.WriteLine("You just made a new Map Object");
        }
        int playerLocation;
        public int getPlayerLocation()
        {
            return playerLocation;
        }
        int wumpusLocation;
        public int getWumpusLocation()
        {
            return wumpusLocation;
        }
        int BatLocation;
        public int getBatLocation()
        {
            return BatLocation;
        }
    }
}

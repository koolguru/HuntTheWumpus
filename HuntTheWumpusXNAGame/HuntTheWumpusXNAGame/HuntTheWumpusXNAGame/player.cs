using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpusXNAGame
{
    class Player
    {
        public Player()
        {
            Console.WriteLine("You just made a new Player Object");
        }
        //Records and holds the number of moves taken by the player, sent to gui to display final results
        public static int Moves()
        {
            return 0;
        }


        //Keeps track of current Player score, and later sends to Score object, and gui
        public static int Score()
        {
            return 0;
        }


        //Holds the number of arrows used by the player, then sends to Gui
        public static int Arrows()
        {
            return 0;
        }


        //Keeps track of player position in the game, the state of the player
        //(which cave, bottomless pit, bat, etc)
        public static void Location()
        {
        }
    }
}

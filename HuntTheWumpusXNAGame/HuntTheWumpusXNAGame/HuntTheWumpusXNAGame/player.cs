using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpusXNAGame
{
    public class Player
    {

        //Holds the number of arrows used by the player, then sends to Gui
        public static int Arrows { get; set; }
        public static int Gold { get; set; }
        //Keeps track of player position in the game, the state of the player
        //(which cave, bottomless pit, bat, etc)
        public static NodeTest Location;
        public Player(PlayerTest test, int arrows, int gold)
        {
            Location = test.room;
            Arrows = arrows;
            Gold = gold;
        }
        public void Update(PlayerTest test)
        {
            Location = test.room;
        }
    }
}

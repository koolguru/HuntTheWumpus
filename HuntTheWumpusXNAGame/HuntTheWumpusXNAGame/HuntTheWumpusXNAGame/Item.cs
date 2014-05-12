using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HuntTheWumpusXNAGame
{
    public class Item
    {
        public string name;
        public string flavorText;
        public Texture2D texture;
        public Rectangle bounding;
        public int value;
        public Item(string name, string flavorText, Texture2D texture, Rectangle bounding, int value)
        {
            this.name = name;
            this.flavorText = flavorText;
            this.texture = texture;
            this.bounding = bounding;
            this.value = value;
        }
        public void Sell()
        {
            Game1.highScore.GoldLeft += value;
            Game1.player.items.Remove(this);
        }
    }
}

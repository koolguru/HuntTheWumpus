using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HuntTheWumpusXNAGame
{
    public class Hexagon
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int displaceX;
        public int displaceY;
        public Line twelve;
        public Line two;
        public Line four;
        public Line six;
        public Line eight;
        public Line ten;
        public Point a;
        public Point b;
        public Point c;
        public Point d;
        public Point e;
        public Point f;
        public NodeTest room;
        public Hexagon(int x, int y, int width, int height, NodeTest room)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            a = new Point(x + 151, y);
            b = new Point(x + 200, y + 100);
            c = new Point(x + 151, y + 200);
            d = new Point(x + 48, y + 200);
            e = new Point(x, y + 100);
            f = new Point(x + 48, y);
            this.twelve = new Line(f.X, f.Y, a.X, a.Y);
            this.two = new Line(a.X, a.Y, b.X, b.Y);
            this.four = new Line(c.X, c.Y - 1, b.X, b.Y);
            this.six = new Line(d.X, d.Y, c.X, c.Y);
            this.eight = new Line(e.X - 1, e.Y + 1, d.X, d.Y);
            this.ten = new Line(e.X, e.Y - 1, f.X, f.Y - 1);
            this.room = room;
            this.Update();
        }
        public void Update()
        {
            twelve.ints.Clear();
            two.ints.Clear();
            four.ints.Clear();
            six.ints.Clear();
            eight.ints.Clear();
            ten.ints.Clear();
            a = new Point(x + 151, y);
            b = new Point(x + 200, y + 100);
            c = new Point(x + 151, y + 200);
            d = new Point(x + 48, y + 200);
            e = new Point(x, y + 100);
            f = new Point(x + 48, y);
            this.twelve = new Line(f.X, f.Y + 1, a.X, a.Y + 1);
            this.two = new Line(a.X, a.Y, b.X, b.Y);
            this.four = new Line(c.X, c.Y - 1, b.X, b.Y);
            this.six = new Line(d.X, d.Y, c.X, c.Y);
            this.eight = new Line(e.X - 1, e.Y, d.X, d.Y);
            this.ten = new Line(e.X, e.Y - 1, f.X + 1, f.Y);
        }
        public void checkArea(Point point, PlayerTest player)
        {
            Rectangle bounding = new Rectangle(Convert.ToInt32(room.pos.X) + 50, Convert.ToInt32(room.pos.Y), 75, 200);
            if (player.bounding.Intersects(bounding))
            {
                player.room = this.room;
                Game1.highScore.GoldLeft++;
                Game1.highScore.NumberOfTurns++;
            }
        }
        public bool testUp(PlayerTest player)
        {
            if (twelve.Test(player, 0, this) && two.Test(player, 1, this) && ten.Test(player, 5, this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool testDown(PlayerTest player)
        {
            if (six.Test(player, 3, this) && four.Test(player, 2, this) && eight.Test(player, 4, this))
            {
                    return true;
            }
            else
            {
                return false;
            }
        }
        public bool testRight(PlayerTest player)
        {
            if (two.Test(player, 1, this) && four.Test(player, 2, this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool testLeft(PlayerTest player)
        {
            if (ten.Test(player, 5, this) && eight.Test(player, 4, this))
            {
                    return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class Line
    {
        public int ax;
        public int ay;
        public int bx;
        public int by;
        public double slope;
        public double b;
        public List<Vector2> ints = new List<Vector2>();
        public Line(int ax, int ay, int bx, int by)
        {
            if (ax - bx != 0)
            {
                slope = (ay - by) / (ax - bx);
            }
            else
            {
                slope = 0;
            }
            b = -1 * ((slope * ax) - ay);
            for (int i = 0; i < Math.Abs(ax - bx) + 1; i++)
            {
                ints.Add(new Vector2(i + ax, Convert.ToInt32((slope * (i + ax)) + b)));
                for (int ii = 0; ii < Math.Abs(slope); ii++)
                {
                    ints.Add(new Vector2(i + ax, Convert.ToInt32((slope * (i + ax)) + b + ii)));
                }
            }
        }
        public bool Test(PlayerTest player, int num, Hexagon hex)
        {
            bool temp = true;
            if (hex.room.Connections[num])
            {
                foreach (Vector2 v in ints)
                {
                    if (new Rectangle(player.bounding.X, player.bounding.Y, 1, 1).Contains(new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1)))
                    {
                        temp = false;
                    }
                }
            }
            return temp;
        }
    }
}
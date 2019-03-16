using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Obj
    {
        public Bitmap Img { get; protected set; }
        public int X { get; set;}
        public int Y { get; set; }

        public int Size { get; protected set; }

        public Obj()
        {
            X = MainForm.rnd.Next(0, 25);
            Y = MainForm.rnd.Next(0, 25);
            Size = 25;
        }
        public Obj(int x, int y)
        {
            X = x;
            Y = y;
            Size = 25;
        }

        public bool Collide(Obj obj)
        {
            if (X == obj.X && Y == obj.Y || X < 0 || X >= 26 || Y < 0 || Y >= 26)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

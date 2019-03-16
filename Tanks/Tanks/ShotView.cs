using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    public class ShotView:Shot
    {
        public ShotView() : base()
        { }
        public ShotView(int x, int y) : base(x, y)
        { }
        public ShotView(int x, int y, int movementdirection) : base(x, y)
        { }

        public ShotView(int x, int y, int direction, MovingObject sender) : base(x, y, direction)
        {
            PrevX = x;
            PrevY = y;
            Sender = sender;
        }

        public override void ChangeImage()
        {
            if (Img == null)
            {
                Img = new Bitmap(Resources.shotRight);
            }
            switch (MovementDirection)
            {
                case (int)Direction.UP:
                    {
                        Img = Resources.shotUp;
                        break;
                    }
                case ((int)Direction.DOWN):
                    {
                        Img = Resources.shotDown;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        Img = Resources.shotRight;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        Img = Resources.shotLeft;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}

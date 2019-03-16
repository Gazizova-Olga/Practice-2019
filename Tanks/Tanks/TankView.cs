using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    public class TankView:Tank
    {
        public TankView() : base()
        { }
        public TankView(int x, int y) : base(x, y)
        { }
        public TankView(int x, int y, int movementdirection) : base(x, y)
        { }
        public override void ChangeImage()
        {
            if (Img == null)
            {
                Img = new Bitmap(Resources.tankRight);
            }
            switch (MovementDirection)
            {
                case (int)Direction.UP:
                    {
                        Img = Resources.tankUP;
                        break;
                    }
                case ((int)Direction.DOWN):
                    {
                        Img = Resources.tankDown;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        Img = Resources.tankRight;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        Img = Resources.tankLeft;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}

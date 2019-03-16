using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks
{
    public class KolobokView : Kolobok
    {
        public KolobokView() : base()
        { }
        public KolobokView(int x, int y) : base(x, y)
        { }
        public KolobokView(int x, int y, int movementdirection) : base(x, y)
        { }
        public override void ChangeImage()
        {
            if (Img == null)
            {
                Img = new Bitmap(Resources.kolobokRight);
            }
            switch (MovementDirection)
            {
                case (int)Direction.UP:
                    {
                        Img = Resources.kolobokUp;
                        break;
                    }
                case ((int)Direction.DOWN):
                    {
                        Img = Resources.kolobokDown;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        Img = Resources.kolobokRight;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        Img = Resources.kolobokLeft;
                        break;
                    }
                default:
                    break;
            }
        }
    
    }
}
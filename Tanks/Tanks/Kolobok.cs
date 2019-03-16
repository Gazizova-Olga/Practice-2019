using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public abstract class Kolobok : MovingObject
    {
        public Kolobok(): base()
        {
        }

        public Kolobok(int x, int y) : base(x, y)
        {
        }

        public void Move(List<FixedObject> Obstacles)
        {
            switch (MovementDirection)
            {
                case (int)Direction.DOWN:
                    {
                        PrevY = Y;
                        PrevX = X;
                        Y++;
                        if (CollideWithFixedObjects(Obstacles))
                        {
                            Y--;
                            IdentifyMovementDirection((int)Direction.UP);
                        }
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        PrevY = Y;
                        PrevX = X;
                        X--;
                        if (CollideWithFixedObjects(Obstacles))
                        {
                            X++;
                            IdentifyMovementDirection((int)Direction.RIGHT);
                        }
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        PrevY = Y;
                        PrevX = X;
                        X++;
                        if (CollideWithFixedObjects(Obstacles))
                        {
                            X--;
                            IdentifyMovementDirection((int)Direction.LEFT);
                        }
                        break;
                    }
                case (int)Direction.UP:
                    {
                        PrevY = Y;
                        PrevX = X;
                        Y--;
                        if (CollideWithFixedObjects(Obstacles))
                        {
                            Y++;
                            IdentifyMovementDirection((int)Direction.DOWN);
                        }
                        break;
                    }
                default:
                    break;
            }
            ChangeImage();
        }
        public event Fire Shooting;
        public void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (sender is KolobokView)
            {
                switch (e.KeyData)
                {
                    case Keys.Up:
                    case Keys.W:
                        {
                            ((KolobokView)sender).IdentifyMovementDirection((int)Direction.UP);
                            break;
                        }
                    case Keys.Down:
                    case Keys.S:
                        {
                            ((KolobokView)sender).IdentifyMovementDirection((int)Direction.DOWN);
                            break;
                        }
                    case Keys.Left:
                    case Keys.A:
                        {
                            ((KolobokView)sender).IdentifyMovementDirection((int)Direction.LEFT);
                            break;
                        }
                    case Keys.Right:
                    case Keys.D:
                        {
                            ((KolobokView)sender).IdentifyMovementDirection((int)Direction.RIGHT);
                            break;
                        }
                    case Keys.F:
                        {
                            Shooting?.Invoke(this);
                            break;
                        }
                    default:
                        break;
                }


            }
        }

    }
}

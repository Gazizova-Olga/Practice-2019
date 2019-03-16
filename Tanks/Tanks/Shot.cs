using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public abstract class Shot:MovingObject
    {
        public MovingObject Sender { get; protected set; }
        public Shot() : base()
        {
        }

        public Shot(int x, int y) : base(x, y)
        {
            PrevX = x;
            PrevY = y;
        }

        public Shot(int x, int y, int direction) : base(x, y, direction)
        {
            PrevX = x;
            PrevY = y;
        }

        public Shot(int x, int y, int direction, MovingObject sender) : base(x, y, direction)
        {
            PrevX = x;
            PrevY = y;
            Sender = sender;
        }

        public void Move()
        {
            switch (MovementDirection)
            {
                case (int)Direction.UP:
                    {
                        PrevY = Y;
                        PrevX = X;
                        Y--;
                        break;
                    }
                case (int)Direction.DOWN:
                    {
                        PrevY = Y;
                        PrevX = X;
                        Y++;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        PrevY = Y;
                        PrevX= X;
                        X--;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        PrevY = Y;
                        PrevX = X;
                        X++;
                        break;
                    }
                default:
                    break;
            }
            ChangeImage();
        }

        public int InteractWithFixedObjects(List<FixedObject> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (Collide(obstacles[i]))
                {
                    if (obstacles[i].Ability == 0)
                    {
                        return i;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return -2;
        }
     }
}

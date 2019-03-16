using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
     public abstract class MovingObject:Obj
    {
        public int PrevX { get; protected set; }
        public int PrevY { get; protected set; }
        public int MovementDirection { get; set; }

        public delegate void Fire(MovingObject sender);

        public MovingObject() : base()
        {
            MovementDirection = MainForm.rnd.Next(0, 4);
            ChangeImage();
        }

        public MovingObject(int x, int y) : base(x, y)
        {
            MovementDirection = MainForm.rnd.Next(0, 4);
            ChangeImage();
        }

        public MovingObject(int x, int y, int direction) : base(x, y)
        {
            MovementDirection = direction;
            ChangeImage();
        }

        public void IdentifyMovementDirection(int direction)
        {
            switch (direction)
            {
                case (int)Direction.DOWN:
                    {
                        MovementDirection = (int)Direction.DOWN;
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        MovementDirection = (int)Direction.LEFT;
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        MovementDirection = (int)Direction.RIGHT;
                        break;
                    }
                case (int)Direction.UP:
                    {
                        MovementDirection = (int)Direction.UP;
                        break;
                    }
                default:
                    break;
            }
        }

        public virtual bool CollideWithFixedObjects(List<FixedObject> Obstacles)
        {
            foreach (var item in Obstacles)
            {
                if (Collide(item))
                {
                    return true;
                }
            }
            return false;
        }
        public abstract void ChangeImage();

        
    }
}

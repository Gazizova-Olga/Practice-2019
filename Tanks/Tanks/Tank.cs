using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public abstract class Tank:MovingObject
    {
        private Random rnd = new Random();
        public Tank() : base()
        {
        }

        public Tank(int x, int y) : base(x, y)
        {
        }

        public event Fire Shooting;

        public void Move(List<FixedObject> Obstacles, List<TankView> Tanks)
        {
            if (rnd.NextDouble() < 0.3)
            {
                IdentifyMovementDirection(MainForm.rnd.Next(0, 4));
            }

            if (rnd.NextDouble() < 0.15)
            {
                Shooting?.Invoke(this);
            }


            switch (MovementDirection)
            {
                case (int)Direction.DOWN:
                    {
                        PrevY = Y;
                        PrevX = X;
                        Y++;
                        if (CollideWithFixedObjects(Obstacles) || CollidesWithTanks(Tanks))
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
                        if (CollideWithFixedObjects(Obstacles) || CollidesWithTanks(Tanks))
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
                        if (CollideWithFixedObjects(Obstacles) || CollidesWithTanks(Tanks))
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
                        if (CollideWithFixedObjects(Obstacles) || CollidesWithTanks(Tanks))
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


        public bool CollidesWithTanks(List<TankView> Tanks)
        {
            for (int i = 0; i < Tanks.Count; i++)
            {
                if (Collide(Tanks[i]) && this!= Tanks[i])
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}

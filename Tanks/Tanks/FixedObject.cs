using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
      public class FixedObject:Obj
    {
        public int Ability { get; set; }
        public FixedObject() : base()
        {
        }
        public FixedObject(int ability) : base()
        {
            Ability = ability;
            if (ability == 0)
            {
                Img = new Bitmap(Resources.wall);
            }
            else
            {
                Img = new Bitmap(Resources.river);
            }
        }
        public FixedObject(int x, int y, int ability) : base(x, y)
        {
            X = x;
            Y = y;
            Ability = ability;
            if (ability == 0)
            {
                Img = new Bitmap(Resources.wall);
            }
            else
            {
                Img = new Bitmap(Resources.river);
            }
        }

        public void IdentifyAbility(int ability)
        {
            switch (ability)
            {
                case (int)Property.ToBeBroken:
                    {
                        Ability = (int)Property.ToBeBroken;
                        break;
                    }
                case (int)Property.ToBeIgnored:
                    {
                        Ability = (int)Property.ToBeIgnored;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}

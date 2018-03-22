using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public class Spatula
    {
        public virtual void Smack()
        {
            Console.WriteLine("Smack someone with spatula");
        }
    }

    public class Catapult: Spatula
    {
        public override void Smack()
        {
            Console.WriteLine("Smack someone with a bolder launched from your catapult");
        }

        public int CalcRange(int bolderSize)
        {
            return 100;
        }
    }
}

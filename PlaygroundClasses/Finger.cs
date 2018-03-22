using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public class Finger<T>: IPoke, IPoke<T>
    {
        public void DoIt(int n)
        {
            Console.WriteLine("DoIt base: " + n);
        }

        public void DoIt(T n)
        {
            Console.WriteLine("IPoke<Int> " + n);
        }
    }
}

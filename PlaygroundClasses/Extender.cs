using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public class Extender<T>: IPoke, IPoke<T>
    {
        void IPoke.DoIt(int n)
        {
            Console.WriteLine("So basic " + n);
        }

        public void DoIt(T n)
        {
            Console.WriteLine("Generic " + n);
        }

    }
}

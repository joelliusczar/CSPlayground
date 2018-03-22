using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public  class Hooten
    {
        public int GetThatNumba(int num)
        {
            return num * 2;
        }

        public virtual void HootYo()
        {
            Console.WriteLine("og way");
        }
    }
}

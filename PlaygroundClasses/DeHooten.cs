using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public class DeHooten: Hooten
    {
        public int HootNum()
        {
            return 5;
        }

        public override void HootYo()
        {
            Console.WriteLine( "new way");
        }
    }
}

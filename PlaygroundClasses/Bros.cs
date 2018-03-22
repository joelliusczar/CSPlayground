using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public class OlderBro
    {
        public void CoverYou()
        {
            Console.WriteLine("I got you, little bro!");
        }
    }

    public class YoungerBro: OlderBro
    {
        public new void CoverYou()
        {
            Console.WriteLine("No, I got you, big bro!");
        }
    }
}

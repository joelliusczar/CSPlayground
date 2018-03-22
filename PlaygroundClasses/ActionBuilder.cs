using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public class ActionBuilder
    {
        public string HighFive { get; set; } = "High Five";

        public Action BuildAction()
        {
            string insideOut = "From in here";
            Action a =  () => {
                Console.WriteLine(insideOut);
                Console.WriteLine(this.HighFive);
            };

            insideOut = "It cha-cha-cha changed!";

            return a;
        }

        public void DoSomeActionyStuff()
        {
            string changable = "Og yo!";

            Action a = () => {
                changable = "Changed inside";
                Console.WriteLine(changable);
            };
            a();
            Console.WriteLine(changable);
        }

        public Action GetTheDevilsIncrementer()
        {
            int num = 0;
            return () => {
                num++;
                Console.WriteLine("devil's num is: " + num);
            };
        }
    }
}

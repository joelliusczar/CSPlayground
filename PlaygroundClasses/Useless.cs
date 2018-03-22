using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PlaygroundClasses
{
    public class ReflectionStuff
    {
        public static void RunThatStuffIntoAMirror()
        {
            Type t = typeof(Useless);
            MethodInfo m0 = t.GetMethod("IsUseless");
            MethodInfo m1 = t.GetMethod("GetGibberish");
            m0.IsDefined(typeof(UselessAttribute));
            m1.IsDefined(typeof(UselessAttribute));

        }
  
    }

    public class Useless
    {
        [Useless]
        public bool IsUseless()
        {
            return true;
        }

        public string GetGibberish()
        {
            return "Nachos in hot coffee on top of a mountain buried under Sky Needle.";
        }
    }
}

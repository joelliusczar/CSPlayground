using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Experiments.outThere
{
    public static class Adderbrutes
    {

        public static IEnumerable<T> GetAttributes<T>(this Type toop) where T: Attribute
        {
            foreach(T a in toop.GetTypeInfo().GetCustomAttributes(typeof(T),false))
            {
                yield return a;
            }
        }
    }
}

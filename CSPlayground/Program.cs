using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CSPlayground
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.ReadKey();
        }

        


        public static void JenericStuph()
        {
            Type bh = typeof(BigHead);
            Type jPlurType = typeof(JenericaPluralis<object,object,object>);
            Type jenericType = jPlurType.GetGenericTypeDefinition().MakeGenericType(new[] { typeof(String),typeof(BigHead),typeof(int) });
            JenericaPluralis<object,object,object> obj = (JenericaPluralis<object, object, object>)Activator.CreateInstance(jenericType);

        }


    }
}

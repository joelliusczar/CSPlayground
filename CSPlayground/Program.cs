using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace CSPlayground
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            IsStuff();
            Console.ReadKey();
        }

        public static void DoActionStuff()
        {
            ActionBuilder ab = new ActionBuilder();
            Action a = ab.BuildAction();
            a();
            ab.DoSomeActionyStuff();
            Action a2 = ab.GetTheDevilsIncrementer();
            a2();
            a2();
            a2();
        }



        public static void CastingStuff()
        {
            Hooten hey = new Hooten();
            DeHooten heHey = hey as DeHooten;

            heHey = new DeHooten();
            Hooten woah = heHey as Hooten;
            woah.HootYo();
        }


        public static void JenericStuph()
        {
            Type bh = typeof(BigHead);
            Type jPlurType = typeof(JenericaPluralis<object,object,object>);
            Type jenericType = jPlurType.GetGenericTypeDefinition().MakeGenericType(new[] { typeof(String),typeof(BigHead),typeof(int) });
            JenericaPluralis<object,object,object> obj = (JenericaPluralis<object, object, object>)Activator.CreateInstance(jenericType);

        }

        public static void IsStuff()
        {
            object dh = new Catapult();

            if(dh is Catapult c)
            {
                c.Smack();

                if(c.CalcRange(0) is 100)
                {
                    Console.WriteLine("it is!");
                }
            }
        }


    }
}

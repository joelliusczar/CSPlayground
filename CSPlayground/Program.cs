using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using BatAndBallEF;


namespace CSPlayground
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            BaseballEntityStuff();
            Console.ReadKey();
        }

        public static void BaseballEntityStuff()
        {
            Baseball_DBEntities dbItems = new Baseball_DBEntities();
            Team t = dbItems.Teams.First();
            Console.WriteLine(t.TeamName);
        }

        public static void DemoBros(OlderBro bro)
        {
            bro.CoverYou();
        }

        public static void CastNullToSomething()
        {
            Catapult a = null;

            object obj = a;

            AcceptsCatapults((Catapult)obj);
        }

        public static void AcceptsCatapults(Catapult c)
        {
            if(c == null)
            {
                Console.WriteLine("It made it through");
                return;
            }
            c.Smack();
        }


        public static void ExplicitInterfaces()
        {
            Finger<int> f = new Finger<int>();
            f.DoIt(7);

            Extender<int> e = new Extender<int>();
            e.DoIt(19);

            ((IPoke)e).DoIt(18);

            Ashtonishing ash = new Ashtonishing();

            ((ITrash)ash).DoAshStuff();
            
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

        public static void FirstAsync()
        {
            Console.WriteLine("Very First Print Statement");
            Task task = SecondAsync();

            long safeCount = 0;
            while(!task.IsCompleted&&safeCount < int.MaxValue)
            {
                if (safeCount % 10000000 == 0)
                {
                    Console.WriteLine("Still Waiting");
                }
                safeCount++;
            } 
            Console.WriteLine("Done asyncing and safe count is "+ safeCount);
        }


        public static async Task SecondAsync()
        {
            Console.WriteLine("About to call wait some shit first time");
            await WaitSomeShit(3000);
            Console.WriteLine("Done with wait some shit first time");
            Console.WriteLine("About to Wait myself some");
            Task.Delay(500).Wait();
            Console.WriteLine("Done with myself waiting");
            Console.WriteLine("About to call wait some shit second time");
            await WaitSomeShit(2000);
            Console.WriteLine("Done with wait some shit second time");

        }

        public static async Task WaitSomeShit(int t)
        {
            Console.WriteLine("About to Wait for "+t+" seconds");
            await Task.Delay(t);
            Console.WriteLine("Finished waiting for "+t+" seconds");
        }

    }
}

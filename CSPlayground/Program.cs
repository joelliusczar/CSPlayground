using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using BatAndBallEF;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.EntityClient;
using PlaygroundClasses;
using PlaygroundOther;
using System.Data.Entity;


namespace CSPlayground
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            SkipSomeEntities();
            Console.ReadKey();
        }

        public static void SkipSomeEntities()
        {
            Baseball_DBEntities bbe = new Baseball_DBEntities();
            int skip = 3;
            var result = bbe.Teams.OrderBy(t => t.LeagueFK).Skip(() => skip).ToList();
        }

        private static void EnumeratorStuff()
        {
            var enumer = EvenNumbers().GetEnumerator();
            var ans = enumer.Current;
            enumer.MoveNext();
            ans = enumer.Current;
            enumer.MoveNext();
            ans = enumer.Current;
        }

        public static void SelectStuff()
        {
            var names = new[] { "Graham", "Ricter", "Salmon" }.AsQueryable();

            var output = names.Select((s, i) => new { name = s, index = i }).ToList();

        }

        public static void NullConditionalStuff()
        {
            PlaygroundOther.StNullGuy st = new PlaygroundOther.StNullGuy();
            PlaygroundClasses.StNullGuy guy = new PlaygroundClasses.StNullGuy();
            Console.WriteLine("This value is: {0} What do you think?", guy.ToString());
            guy = null;
            Console.WriteLine("This value is: {0} What do you think?", guy?.ToString());
            Console.WriteLine("Mynt is {0}", guy?.Mynt);
            if (guy?.Mynt == 0)
            {
                Console.WriteLine("if is true");
            }
            else
            {
                Console.WriteLine("No true is");
            }

        }

        public static void DTStringFormat()
        {
            DateTime date1 = new DateTime(2008, 8, 29, 19, 27, 15, 18);
            Console.WriteLine(date1.ToString("d-MMM-yy"));
        }

        public static void ConcatEFInterceptTest()
        {
            Baseball_DBEntities dbItems = new Baseball_DBEntities();
            var items =  from team in dbItems.Teams
            select new { exName = "Team:" + team.TeamName };
            Console.WriteLine(items.First().exName);
        }

        public static void SkipSome()
        {
            var nums = EvenNumbers().Skip(10).Take(5);
            foreach(int num in nums)
            {
                Console.WriteLine("{0} of list that has been taken",num);
            }
        }

        public static IEnumerable<int> EvenNumbers()
        {
            int i = 0;
            for(; ; )
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Generating: {0}",i);
                    yield return i;
                }
                i++;
            }
        }


        public static void DateCheck()
        {
            DateTime dt = new DateTime(1988, 4, 27).ToUniversalTime();
            DateTime plusTime = dt.AddYears(19);
            DateTime febDay = new DateTime(1988, 2, 29).ToUniversalTime();
            DateTime febPlus = febDay.AddYears(2);
        }

        public static void ConnectionStringStuff()
        {
            ConnectionStringSettingsCollection collection = ConfigurationManager.ConnectionStrings;;
            ConnectionStringSettings setting = collection[1];
            string connectStr = setting.ConnectionString;
            EntityConnectionStringBuilder efStrBuilder = new EntityConnectionStringBuilder(connectStr);
            SqlConnectionStringBuilder sqlConnectStrBuilder = new SqlConnectionStringBuilder(efStrBuilder.ProviderConnectionString);
            
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

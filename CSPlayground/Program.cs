using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.EntityClient;
using PlaygroundClasses;
using PlaygroundOther;
using System.Data.Entity;
using KenGriffeyJrEF;
using KenGriffeyJrShips;
using WorkPlayground;


namespace CSPlayground
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            GetAllDumbs();
            Console.ReadKey();
        }

        public static void GetAllDumbs()
        {
        
            BigHead bigHead = new BigHead();
            //.Where(p => p.DeclaringType == typeof(BigHead))
            var ps = bigHead.GetType()
                .GetProperties().Where(p => {
                    var m = p.GetCustomAttributes<DumbAttribute>().Count() > 0;
                    return m;
                    }).OrderBy(p => {

                        var i = p.GetCustomAttribute<DumbAttribute>().TestValue;
                        return i;
                    }).ToList();
            ;
        }

        public static void DateTimeDate()
        {
            DateTime dt1 = DateTime.Now;
            var dt2 = dt1.Date;
            Console.WriteLine($" Compare dt1: {dt1}\n to dt2: {dt2}");
        }

        public static void DemoPropDefaultSet()
        {
            Console.WriteLine("First we print");
            NumTwo n2 = new NumTwo();
            Console.WriteLine(n2.HisFavoriteNumber);
            Console.WriteLine("Do it again!");
            Console.WriteLine(n2.HisFavoriteNumber);
        }

        public static void AltBaseballTry()
        {
            KenGriffeyJrShipsDbEntities alt = new KenGriffeyJrShipsDbEntities();
            var allTeamCount = alt.Teams.Count();
            var l = alt.Teams.Where(t => t.League != null).ToList();
        }

        public static void UnionTest()
        {
            var nums1 = new int[] { 1, 3, 2, 11, 32, 7, 8 }.AsQueryable();
            var excludo = nums1.Where(n => n != 11);
            var nums2 = new int[] { 1, 12, 5,11,8 }.AsQueryable();
            var uSet = nums2.Union(excludo);
            var l = uSet.ToList();
            
        }

        public static void ExceptTest()
        {
            KenGriffeyJrDbEntities entities = new KenGriffeyJrDbEntities();
            int count = entities.Teams.Count();
            var notSet = entities.Teams.Where(t => !t.LeagueFk.HasValue);
            var notList = notSet.ToList();
            var theRest = entities.Teams.Except(notSet).ToList();
        }

        public static void StrInterpolateName()
        {
            Console.WriteLine($"The method below this might be {nameof(NullRefsInExpress)}");
        }

        public static void NullRefsInExpress()
        {
            var lns = new List<PlaygroundClasses.StNullGuy>
            {
                new PlaygroundClasses.StNullGuy{
                    Mynt = 5,
                    MiniNull = new PlaygroundClasses.StNullGuy{
                        Mynt = 8,
                    }
                },
                new PlaygroundClasses.StNullGuy{
                    Mynt = 6,
                    MiniNull = new PlaygroundClasses.StNullGuy{
                        Mynt = 9,
                    }
                },
                new PlaygroundClasses.StNullGuy{
                    Mynt = 7,
                },
                new PlaygroundClasses.StNullGuy{
                    Mynt = 10,
                    MiniNull = new PlaygroundClasses.StNullGuy{
                        Mynt = 11,
                    }
                },
                new PlaygroundClasses.StNullGuy{
                    Mynt = 12,
                },
                new PlaygroundClasses.StNullGuy{
                    Mynt = 13,
                },
            }.AsQueryable();

           // var filtered = lns.Where(n => n.MiniNull?.Mynt > 8).ToList();
        }

        public static void EnumToList()
        {
            var l0 = Enum.GetValues(typeof(Silberware));
            var l1 = Enum.GetValues(typeof(Silberware)).Cast<Silberware>();
            var l2 = ((Silberware[])Enum.GetValues(typeof(Silberware))).ToList();
        }

        public static void SkipSomeEntities()
        {
            KenGriffeyJrDbEntities bbe = new KenGriffeyJrDbEntities();
            int skip = 3;
            var result = bbe.Teams.OrderBy(t => t.LeagueFk).Skip(() => skip).ToList();
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
            KenGriffeyJrDbEntities dbItems = new KenGriffeyJrDbEntities();
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
            KenGriffeyJrDbEntities dbItems = new KenGriffeyJrDbEntities();
            KenGriffeyJrEF.Team t = dbItems.Teams.First();
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

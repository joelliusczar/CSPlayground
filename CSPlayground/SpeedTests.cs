using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PlaygroundClasses;

namespace CSPlayground
{
    public class SpeedTests
    {
        public static void RunAllTests()
        {
            RunTest(() => TimeDict(), "Dict");
            RunTest(() => TimeList(), "List");
            RunTest(() => TimeSwitch(),"Switch");
        }

        public static void RunTest(Action runTest,string testName)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            for (long i = 0; i < 1000000; i++)
            {
                runTest();
            }
            s.Stop();
            Console.WriteLine($"{testName} took {s.ElapsedMilliseconds}");
        }

        public static void TimeDict()
        {
            var st = DictionaryToList.dictList[35];
        }

        public static void TimeList()
        {
            var l = DictionaryToList.numer[35];
        }

        public static void TimeSwitch()
        {
            var s = DictionaryToList.UseTheSwitch(35);
        }

    }
}

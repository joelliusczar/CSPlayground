using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSPlayground
{
    public static class Statica
    {
        [ThreadStatic]
        private static int a;

        private static int b;

        public static void StringAlongAsync()
        {
            Task.Run(async () => {
                int c = 0;
                for (int i = 0; i < 100; i++)
                {
                    Statica.a++;
                    Console.WriteLine("Async A - a: " + Statica.a);
                    Statica.b++;
                    Console.WriteLine("Async A - b: " + Statica.b);
                    c++;
                    Console.WriteLine("Async A - c: " + c);
                    await Task.Delay(100);
                }
                Console.WriteLine("Done");
                Console.WriteLine("Done Async A - a: " + Statica.a);
                Console.WriteLine("Done Async A - b: " + Statica.b);
                Console.WriteLine("Done Async A - c: " + c);
            });

            Task.Run(async () => {
                int c = 0;
                for (int i = 0; i < 100; i++)
                {
                    
                    Statica.a++;
                    Console.WriteLine("Async B - a: " + Statica.a);
                    Statica.b++;
                    Console.WriteLine("Async B - b: " + Statica.b);
                    c++;
                    Console.WriteLine("Async B - c: " + c);
                    await Task.Delay(100);
                }
                Console.WriteLine("Done");
                Console.WriteLine("Done Async B - a: " + Statica.a);
                Console.WriteLine("Done Async B - b: " + Statica.b);
                Console.WriteLine("Done Async B - c: " + c);
            });
        }

        public static void StringAlong()
        {
            Thread t1 = new Thread(() =>
            {
                int c = 0;
                for (int i = 0; i < 100; i++)
                {
                    Statica.a++;
                    Console.WriteLine("Async A - a: " + Statica.a);
                    Statica.b++;
                    Console.WriteLine("Async A - b: " + Statica.b);
                    c++;
                    Console.WriteLine("Async A - c: " + c);
                    Thread.Sleep(100);
                }
                Console.WriteLine("Done");
                Console.WriteLine("Done Async A - a: " + Statica.a);
                Console.WriteLine("Done Async A - b: " + Statica.b);
                Console.WriteLine("Done Async A - c: " + c);
            });

            Thread t2 = new Thread(() => {
                int c = 0;
                for (int i = 0; i < 100; i++)
                {

                    Statica.a++;
                    Console.WriteLine("Async B - a: " + Statica.a);
                    Statica.b++;
                    Console.WriteLine("Async B - b: " + Statica.b);
                    c++;
                    Console.WriteLine("Async B - c: " + c);
                    Thread.Sleep(100);
                }
                Console.WriteLine("Done");
                Console.WriteLine("Done Async B - a: " + Statica.a);
                Console.WriteLine("Done Async B - b: " + Statica.b);
                Console.WriteLine("Done Async B - c: " + c);
            });

            t1.Start();
            t2.Start();
        }

        public static void StringAlongSleep()
        {
            Task.Run(() => {
                int c = 0;
                for (int i = 0; i < 100; i++)
                {
                    Statica.a++;
                    Console.WriteLine("Async A - a: " + Statica.a);
                    Statica.b++;
                    Console.WriteLine("Async A - b: " + Statica.b);
                    c++;
                    Console.WriteLine("Async A - c: " + c);
                    Thread.Sleep(100);
                }
                Console.WriteLine("Done");
                Console.WriteLine("Done Async A - a: " + Statica.a);
                Console.WriteLine("Done Async A - b: " + Statica.b);
                Console.WriteLine("Done Async A - c: " + c);
            });

            Task.Run(() => {
                int c = 0;
                for (int i = 0; i < 100; i++)
                {

                    Statica.a++;
                    Console.WriteLine("Async B - a: " + Statica.a);
                    Statica.b++;
                    Console.WriteLine("Async B - b: " + Statica.b);
                    c++;
                    Console.WriteLine("Async B - c: " + c);
                    Thread.Sleep(100);
                }
                Console.WriteLine("Done");
                Console.WriteLine("Done Async B - a: " + Statica.a);
                Console.WriteLine("Done Async B - b: " + Statica.b);
                Console.WriteLine("Done Async B - c: " + c);
            });
        }

        public static void StringAlongWait()
        {
            Task.Run(() => {
                int c = 0;
                for (int i = 0; i < 100; i++)
                {
                    Statica.a++;
                    Console.WriteLine("Async A - a: " + Statica.a);
                    Statica.b++;
                    Console.WriteLine("Async A - b: " + Statica.b);
                    c++;
                    Console.WriteLine("Async A - c: " + c);
                    Task.Delay(100).Wait();
                }
                Console.WriteLine("Done");
                Console.WriteLine("Done Async A - a: " + Statica.a);
                Console.WriteLine("Done Async A - b: " + Statica.b);
                Console.WriteLine("Done Async A - c: " + c);
            });

            Task.Run(() => {
                int c = 0;
                for (int i = 0; i < 100; i++)
                {

                    Statica.a++;
                    Console.WriteLine("Async B - a: " + Statica.a);
                    Statica.b++;
                    Console.WriteLine("Async B - b: " + Statica.b);
                    c++;
                    Console.WriteLine("Async B - c: " + c);
                    Task.Delay(100).Wait();
                }
                Console.WriteLine("Done");
                Console.WriteLine("Done Async B - a: " + Statica.a);
                Console.WriteLine("Done Async B - b: " + Statica.b);
                Console.WriteLine("Done Async B - c: " + c);
            });
        }

        public static void StringAlongAsyncSingle()
        {
            Task.Run(async () => {
                int c = 0;
                for (int i = 0; i < 100; i++)
                {
                    Statica.a++;
                    Console.WriteLine("Async A - a: " + Statica.a);

                    await Task.Delay(100);
                }
                Console.WriteLine("Done");
                Console.WriteLine("Done Async A - a: " + Statica.a);
            });

        }

    }
}

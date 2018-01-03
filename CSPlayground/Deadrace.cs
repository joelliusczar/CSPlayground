using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace CSPlayground
{
    public class Deadrace
    {
        public int[] set { get; set; }

        public int total { get; set; }

        private Object thisLock = new Object();

        public Deadrace()
        {
            this.set = new int[10] {3,4,6,8,6,4,2,1,2,3};
        }

        public void RunRace()
        {
            
            Thread t1 = new Thread(() => {
                this.DoSumAction();
            });

            Thread t2 = new Thread(() =>
            {
                this.DoProductAction();
            });

            t1.Start();
            t2.Start();

        }

        private void DoProductAction()
        {
            lock (this.thisLock)
            {
                Random r = new Random();
                int p = this.set.Aggregate(1, (a, b) => a * b);
                this.UpdateTotal(p);
                Thread.Sleep(r.Next(100, 1000));
                Console.WriteLine(String.Format("Total is product: {0}, and it should actually be {1}", this.total, p));
            }
        }

        public void UpdateTotal(int newVal)
        {
            this.total = newVal;
        }

        public void DoSumAction()
        {
            lock (this.thisLock)
            {
                Random r = new Random();
                int s = this.set.Sum();
                this.UpdateTotal(s);
                Thread.Sleep(r.Next(100, 1000));
                Console.WriteLine(String.Format("Total is sum: {0}, and it should actually be {1}", this.total, s));
            }
        }

        
    }
}

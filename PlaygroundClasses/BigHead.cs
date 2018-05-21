using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public class Head
    {
        [Dumb(TestValue = 3)]
        public string SelfName { get; set; }
    }

    public class BigHead: Head
    {
        [Dumb(TestValue = 2)]
        public int NumberOfBrains { get; set; }
        public bool DoBrainsGetAlong { get; set; }
        [Dumb(TestValue = 5)]
        public double Volume { get; set; }
        public string CodeName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakesNews
{
    public static class AnotherNeedlessLayer
    {
        public static TResult CallSomething<T1,T2,T3,TResult>(Func<T1,T2,T3,TResult> function, T1 arg1, T2 arg2, T3 arg3)
        {
            return function(arg1, arg2, arg3);
        }
    }
}

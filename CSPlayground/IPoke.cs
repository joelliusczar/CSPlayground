using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPlayground
{
    interface IPoke
    {
        void DoIt(int n);
    }

    interface IPoke<T>: IPoke
    {
        void DoIt(T n);
    }
}

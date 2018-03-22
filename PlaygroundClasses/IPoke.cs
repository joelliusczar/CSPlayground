using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public interface IPoke
    {
        void DoIt(int n);
    }

    public interface IPoke<T>: IPoke
    {
        void DoIt(T n);
    }
}

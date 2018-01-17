using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    using System.Reflection;
    public interface IMemberEmitter
    {
        MemberInfo Member { get; }
        Type ReturnType { get; }

        void EnsureValidCodeBlock();

        void Generate();
    }
}

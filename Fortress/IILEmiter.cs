using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    using System.Reflection.Emit;
    public interface IILEmiter
    {
        void Emit(IMemberEmitter member, ILGenerator gen);
    }
}

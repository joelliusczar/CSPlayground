using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Fortress
{
    public abstract class Statement: IILEmiter
    {
        public abstract void Emit(IMemberEmitter member, ILGenerator gen);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    using System.Diagnostics;
    public class SelfReference: Reference
    {
        

        public static readonly SelfReference Self = new SelfReference();

        protected SelfReference()
            :base(null)
        { }

        public override void LoadReference(ILGenerator gen)
        {
            gen.Emit(OpCodes.Ldarg_0);
        }
    }
}

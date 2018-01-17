using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    using System.Reflection.Emit;

    public abstract class ArgumentUtil
    {
        public static void EmitLoadOwnerAndReference(Reference reference, ILGenerator il)
        {
            if(reference == null)
            {
                return;
            }

            EmitLoadOwnerAndReference(reference.OwnerReference, il);

            reference.LoadReference(il);
        }
    }
}

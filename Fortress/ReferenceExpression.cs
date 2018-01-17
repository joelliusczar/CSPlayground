using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace Fortress
{


    public class ReferenceExpression: EmExpression
    {
        private readonly Reference reference;

        public ReferenceExpression(Reference reference)
        {
            this.reference = reference;
        }

        public override void Emit(IMemberEmitter member, ILGenerator gen)
        {
            ArgumentUtil.EmitLoadOwnerAndReference(reference, gen);
        }
    }
}

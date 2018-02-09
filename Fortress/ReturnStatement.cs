using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class ReturnStatement: Statement
    {
        private readonly Reference reference;
        private readonly EmExpression emExpression;
        

        public override void Emit(IMemberEmitter member, ILGenerator gen)
        {
            if(this.reference != null)
            {
                ArgumentUtil.EmitLoadOwnerAndReference(this.reference, gen);
            }
            else if(this.emExpression != null)
            {
                this.emExpression.Emit(member, gen);
            }
            else
            {
                if(member.ReturnType != typeof(void))
                {
                    OpCodeUtil.EmitLoadOpCodeForDefaultValueOfType(gen, member.ReturnType);
                }
            }

            gen.Emit(OpCodes.Ret);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace Fortress
{
    public class ConstructorInvocationStatement: Statement
    {
        private readonly EmExpression[] args;
        private readonly ConstructorInfo cmethod;

        public ConstructorInvocationStatement(ConstructorInfo method,params EmExpression[] args)
        {
            if(method == null || args == null)
            {
                throw new ArgumentNullException();
            }

            this.cmethod = method;
            this.args = args;
        }

        public override void Emit(IMemberEmitter member, ILGenerator gen)
        {
            

            gen.Emit(OpCodes.Ldarg_0);

            foreach(EmExpression exp in this.args)
            {
                exp.Emit(member, gen);
            }
            gen.Emit(OpCodes.Call, this.cmethod);

        }
    }
}

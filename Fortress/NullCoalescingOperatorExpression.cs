using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class NullCoalescingOperatorExpression: EmExpression
    {
        private readonly EmExpression @default;
        private readonly EmExpression expression;

        public NullCoalescingOperatorExpression(EmExpression expression,EmExpression @default)
        {
            if(expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if(@default == null)
            {
                throw new ArgumentNullException("default");
            }

            this.expression = expression;
            this.@default = @default;

        }

        public override void Emit(IMemberEmitter member, ILGenerator gen)
        {
            this.expression.Emit(member, gen);
            gen.Emit(OpCodes.Dup);
            Label label = gen.DefineLabel();
            gen.Emit(OpCodes.Brtrue_S, label);
            gen.Emit(OpCodes.Pop);
            @default.Emit(member, gen);
            gen.MarkLabel(label);
        }
    }
}

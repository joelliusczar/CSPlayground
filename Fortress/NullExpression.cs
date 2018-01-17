using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class NullExpression: EmExpression
    {
        public static readonly NullExpression Instance = new NullExpression();

        protected NullExpression()
        { }

        public override void Emit(IMemberEmitter member, ILGenerator gen)
        {
            gen.Emit(OpCodes.Ldnull);
        }
    }
}

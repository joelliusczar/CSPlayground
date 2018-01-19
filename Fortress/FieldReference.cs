using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;

namespace Fortress
{
    public class FieldReference: Reference
    {
        private readonly FieldBuilder fieldBuilder;
        private readonly FieldInfo field;
        private readonly bool isStatic;

        public FieldInfo Reference
        {
            get { return this.field; }
        }

        public FieldReference(FieldBuilder fieldBuilder)
        {
            this.fieldBuilder = fieldBuilder;
            this.field = fieldBuilder;
            if((this.fieldBuilder.Attributes & FieldAttributes.Static) != 0)
            {
                this.isStatic = true;
                this.owner = null;
            }
        }

        public override void LoadReference(ILGenerator gen)
        {
            if(isStatic)
            {
                gen.Emit(OpCodes.Stsfld, Reference);
            }
            else
            {
                gen.Emit(OpCodes.Ldflda, Reference);
            }
        }

    }
}

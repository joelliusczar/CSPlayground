using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class AsTypeReference: Reference
    {
        private readonly Reference reference;
        private readonly Type type;

        public AsTypeReference(Reference reference,Type type)
        {
            if(reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }

            if(type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            this.reference = reference;
            this.type = type;

            if(reference == this.OwnerReference)
            {
                OwnerReference = null;
            }
        }

        public override void LoadReference(ILGenerator gen)
        {
            reference.LoadReference(gen);
            gen.Emit(OpCodes.Isinst, type);
        }


    }
}

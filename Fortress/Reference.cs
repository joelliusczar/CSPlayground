using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    using System.Reflection.Emit;
    public abstract class Reference
    {
        protected Reference owner = SelfReference.Self;

        protected Reference()
        { }

        protected Reference(Reference owner)
        {
            this.owner = owner;
        }

        public Reference OwnerReference
        {
            get { return owner; }
            set { this.owner = value; }
        }

        public abstract void LoadReference(ILGenerator gen);

        public virtual EmExpression ToExpression()
        {
            return new ReferenceExpression(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public class MetaEvent: MetaTypeElement, IEquatable<MetaEvent>
    {
        private readonly MetaMethod adder;
        private readonly MetaMethod remover;
        private readonly Type type;

        private string name;

        public EventAttributes Attributes { get; private set; }

        public MetaEvent(string name, Type declaringType, Type eventDelegateType, MetaMethod adder, MetaMethod remover, EventAttributes attributes)
            :base(declaringType)
        {
            if(adder == null)
            {
                throw new ArgumentNullException(nameof(adder));
            }
            if(remover == null)
            {
                throw new ArgumentNullException(nameof(remover));
            }
            this.name = name;
            this.type = eventDelegateType;
            this.adder = adder;
            this.remover = remover;
            this.Attributes = attributes;
        }

        public bool Equals(MetaEvent other)
        {
            if(ReferenceEquals(null,other))
            {
                return false;
            }
            if(ReferenceEquals(this,other))
            {
                return true;
            }
            if(!this.type.Equals(other.type))
            {
                return false;
            }
            if(!StringComparer.OrdinalIgnoreCase.Equals(this.name,other.name))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (this.adder.Method != null ? this.adder.Method.GetHashCode() : 0);
                result = (result * 397) ^ (this.remover.Method != null ?remover.Method.GetHashCode():0);
                result = (result * 397) ^ (Attributes.GetHashCode());
                return result;
            }
        }

        public override void SwitchToExplicitImplementation()
        {
            this.name = MetaTypeElementUtil.CreateNameForExplicitImplementation(this.sourceType, name);
            this.adder.SwitchToExplicitImplementation();
            this.remover.SwitchToExplicitImplementation();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace Fortress
{
    public class MetaProperty: MetaTypeElement, IEquatable<MetaProperty>
    {
        private string name;
        private readonly MetaMethod getter;
        private readonly MetaMethod setter;
        private readonly Type type;
        private readonly PropertyAttributes attributes;
        private readonly IEnumerable<CustomAttributeBuilder> customAttributes;
        private readonly Type[] arguments;

        public Type[] Arguments
        {
            get { return this.arguments; }
        }

        public MethodInfo GetMethod
        {

        }

        public MetaProperty(string name, Type propertyType, Type declaringType, MetaMethod getter,MetaMethod setter, 
            IEnumerable<CustomAttributeBuilder> customAttributes, Type[] arguments)
            :base(declaringType)
        {
            this.name = name;
            this.type = propertyType;
            this.getter = getter;
            this.setter = setter;
            this.attributes = PropertyAttributes.None;
            this.customAttributes = customAttributes;
            this.arguments = arguments ?? Type.EmptyTypes;
        }

        public override void SwitchToExplicitImplementation()
        {
            name = MetaTypeElementUtil.CreateNameForExplicitImplementation(this.sourceType, this.name);
            if(this.setter != null)
            {
                this.setter.SwitchToExplicitImplementation();
            }
            if(this.getter != null)
            {
                this.getter.SwitchToExplicitImplementation();
            }
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null,obj))
            {
                return false;
            }
            if(ReferenceEquals(this,obj))
            {
                return true;
            }
            if(obj.GetType() != typeof(MetaProperty))
            {
                return false;
            }
            return Equals((MetaProperty)obj);
        }

        public bool Equals(MetaProperty other)
        {
            if(ReferenceEquals(null,other))
            {
                return false;
            }
            if(ReferenceEquals(this,other))
            {
                return true;
            }
            if(!type.Equals(other.type))
            {
                return false;
            }
            if(!StringComparer.OrdinalIgnoreCase.Equals(this.name,other.name))
            {
                return false;
            }
            if(this.Arguments.Length != other.Arguments.Length)
            {
                return false;
            }
            for(int i = 0;i < Arguments.Length;i++)
            {
                if(!this.Arguments[i].Equals(other.Arguments[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return 
            }
        }
    }
}

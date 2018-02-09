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
        private readonly Type[] arguments;
        private readonly PropertyAttributes attributes;
        private readonly IEnumerable<CustomAttributeBuilder> customAttributes;
        private readonly MetaMethod getter;
        private readonly MetaMethod setter;
        private readonly Type type;
        private string name;

        public Type[] Arguments
        {
            get { return arguments; }
        }

        public MethodInfo GetMethod
        {
            get
            {
                if(this.getter == null)
                {
                    throw new InvalidOperationException();
                }
                return this.getter.Method;
            }
        }

        public MethodInfo SetMethod
        {
            get
            {
                if(this.setter == null)
                {
                    throw new InvalidOperationException();
                }
                return this.setter.Method;
            }
        }



        public MetaProperty(string name, Type propertyType, Type declaringType, MetaMethod getter, MetaMethod setter,
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
            this.name = MetaTypeElementUtil.CreateNameForExplicitImplementation(this.sourceType, this.name);
            if(this.setter != null)
            {
                this.setter.SwitchToExplicitImplementation();
            }
            if(this.getter != null)
            {
                this.getter.SwitchToExplicitImplementation();
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.GetMethod != null ? GetMethod.GetHashCode():0) * 397) ^ (this.SetMethod != null? this.SetMethod.GetHashCode():0);
            }
        }

        public override bool Equals(object obj)
        {

            return this.Equals(obj as MetaProperty);
        }

        public bool Equals(MetaProperty other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
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
            if(this.arguments.Length != other.Arguments.Length)
            {
                return false;
            }
            for(int i = 0;i < this.Arguments.Length;i++)
            {
                if(!this.Arguments[i].Equals(other.Arguments[i]))
                {
                    return false;
                }
            }

            return true; 
        }
    }
}

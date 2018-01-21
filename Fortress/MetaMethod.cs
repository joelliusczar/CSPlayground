using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public class MetaMethod: MetaTypeElement, IEquatable<MetaMethod>
    {
        private const MethodAttributes ExplicitImplementationAttributes =
            MethodAttributes.Virtual
            | MethodAttributes.Public
            | MethodAttributes.HideBySig
            | MethodAttributes.NewSlot
            | MethodAttributes.Final;

        private string name;

        public MethodInfo Method { get; private set; }
        public MethodAttributes Attributes { get; private set; }
        public bool Standalone { get; private set; }
        public bool Proxyable { get; private set; }
        public bool HasTarget { get; private set; }
        public MethodInfo MethodOnTarget { get; private set; }


        public string Name
        {
            get { return name; }
        }

        public MetaMethod(MethodInfo method,MethodInfo methodOnTarget, bool standalone, bool proxyable, bool hasTarget)
            :base(method.DeclaringType)
        {
            this.Method = method;
            this.name = method.Name;
            this.MethodOnTarget = methodOnTarget;
            this.Standalone = standalone;
            this.Proxyable = proxyable;
            this.HasTarget = hasTarget;
            this.Attributes = 
        }

        public bool Equals(MetaMethod other)
        {
            if(ReferenceEquals(null,other))
            {
                return false;
            }
            if(ReferenceEquals(this,other))
            {
                return true;
            }

            if(!StringComparer.OrdinalIgnoreCase.Equals(name,other.name))
            {
                return false;
            }

            MethodSignatureComparer comparer = MethodSignatureComparer.Instance;

            if(!comparer.EqualsSignatureTypes(this.Method.ReturnType, other.Method.ReturnType))
            {
                return false;
            }

            if(!comparer.EqualParameters(this.Method,other.Method))
            {
                return false;
            }

            return true;
        }

        public override void SwitchToExplicitImplementation()
        {
            this.Attributes = ExplicitImplementationAttributes;
            if(!this.Standalone)
            {
                this.Attributes |= MethodAttributes.SpecialName;
            }
            this.name = MetaTypeElementUtil.CreateNameForExplicitImplementation(this.sourceType, this.Method.Name);
            
        }

        private MethodAttributes ObtainAttributes()
        {
            MethodInfo methodInfo = this.Method;
            MethodAttributes attributes = MethodAttributes.Virtual;

            if(methodInfo.IsFinal || this.Method.DeclaringType.GetTypeInfo().IsInterface)
            {
                attributes |= MethodAttributes.NewSlot;
            }

            if(methodInfo.IsPublic)
            {
                attributes |= MethodAttributes.Public;
            }

            if(methodInfo.IsHideBySig)
            {
                attributes |= MethodAttributes.HideBySig;
            }
            if(ProxyUtil.IsInternal(methodInfo) && )
        }
    }
}

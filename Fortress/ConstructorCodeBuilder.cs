using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;

namespace Fortress
{
    public class ConstructorCodeBuilder: AbstractCodeBuilder
    {
        private readonly Type baseType;

        public ConstructorCodeBuilder(Type baseType,ILGenerator generator)
            :base(generator)
        {
            this.baseType = baseType;
        }

        public void InvokeBaseConstructor()
        {
            Type type = this.baseType;

            if(type.GetTypeInfo().ContainsGenericParameters)
            {
                type = type.GetGenericTypeDefinition();
            }

            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            ConstructorInfo baseDefaultCtor = type.GetConstructor(flags, null, new Type[0], null);

            this.InvokeBaseConstructor(baseDefaultCtor);
        }

        public void InvokeBaseConstructor(ConstructorInfo constructor)
        {
            this.AddStatement(new ConstructorInvocationStatement(constructor));
        }
    }
}

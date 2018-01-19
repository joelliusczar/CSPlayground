using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace Fortress
{
    public class ClassEmitter: AbstractTypeEmitter
    {
        private readonly ModuleScope moduleScope;

        public ClassEmitter(ModuleScope moduleScope, String name,Type baseType, IEnumerable<Type> interfaces)
        {

        }

        public ClassEmitter(ModuleScope moduleScope,string name, Type baseType, IEnumerable<Type> interfaces,
            TypeAttributes flags, bool forceUnsigned)
            :base(CreateTypeBuilder(moduleScope,name,baseType,interfaces,flags,forceUnsigned))
        {
            interfaces = this.InitializeGenericArgumentsFromBases(ref baseType, interfaces);

            if(interfaces != null)
            {
                foreach(Type inter in interfaces)
                {
                    this.TypeBuilder.AddInterfaceImplementation(inter);
                }
            }

            this.TypeBuilder.SetParent(baseType);
            this.moduleScope = moduleScope;

        }

        private static TypeBuilder CreateTypeBuilder(ModuleScope moduleScope,string name,Type baseType,IEnumerable<Type> interfaces,
            TypeAttributes flags, bool forceUnsigned)
        {
            bool isAssemblySigned = !forceUnsigned && !StrongNameUtil.IsAnyTypeFromUnsignedAssembly(baseType, interfaces);
            return moduleScope.DefineType(isAssemblySigned, name, flags);

        }

        protected virtual IEnumerable<Type> InitializeGenericArgumentsFromBases(ref Type baseType, IEnumerable<Type> interfaces)
        {
            if(baseType != null && baseType.GetTypeInfo().IsGenericTypeDefinition)
            {
                throw new NotSupportedException("No open generics!");
            }

            if(interfaces == null)
            {
                return null;
            }

            foreach(Type inter in interfaces)
            {
                if(inter.GetTypeInfo().IsGenericTypeDefinition)
                {
                    throw new NotSupportedException("no open generic interfaces");
                }

            }
            return interfaces;
        }

    }
}

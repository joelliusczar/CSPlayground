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
        public ClassEmitter(ModuleScope moduleScope, String name,Type baseType, IEnumerable<Type> interfaces)
        {

        }

        public ClassEmitter(ModuleScope moduleScope,string name, Type baseType, IEnumerable<Type> interfaces,
            TypeAttributes flags, bool forceUnsigned)
        { }

        private static TypeBuilder CreateTypeBuilder(ModuleScope moduleScope,string name,Type baseType,IEnumerable<Type> interfaces,
            TypeAttributes flags, bool forceUnsigned)
        {
            bool isAssemblySigned = !forceUnsigned && !StrongNameUtil.IsAnyTypeFromUnsignedAssembly(baseType, interfaces);
            return moduleScope.

        }

    }
}

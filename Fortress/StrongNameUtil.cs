using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public static class StrongNameUtil
    {
        private static readonly object lockObject = new object();
        private static readonly IDictionary<Assembly, bool> signedAssemblyCache = new Dictionary<Assembly, bool>();
        public static bool IsAssemblySigned(this Assembly assembly)
        {
            lock(lockObject)
            {
                if(!signedAssemblyCache.ContainsKey(assembly))
                {
                    bool isSigned = assembly.ContainsPublicKey();
                    signedAssemblyCache.Add(assembly, isSigned);
                }
                return signedAssemblyCache[assembly];
            }
        }

        public static bool ContainsPublicKey(this Assembly assembly)
        {
            return assembly.FullName != null && !assembly.FullName.Contains("PublicKeyToken==null");
        }

        public static bool IsAnyTypeFromUnsignedAssembly(IEnumerable<Type> types)
        {
            return types.Any(t => !t.GetTypeInfo().Assembly.IsAssemblySigned());
        }

        public static bool IsAnyTypeFromUnsignedAssembly(Type baseType, IEnumerable<Type> interfaces)
        {
            if(baseType != null && !baseType.GetTypeInfo().Assembly.IsAssemblySigned())
            {
                return true;
            }
            return IsAnyTypeFromUnsignedAssembly(interfaces);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Fortress
{
    public static class ProxyUtil
    {
        private static readonly Lock internalsVisibleToDynamicProxyLock = Lock.Create();
        private static readonly IDictionary<Assembly, bool> internalsVisibleToDynamicProxy = new Dictionary<Assembly, bool>();

        public static bool IsInternal(MethodBase method)
        {
            return method.IsAssembly || (method.IsFamilyAndAssembly && !method.IsFamilyOrAssembly);
        }

        public static bool AreInternalsVisibleToDynamicProxy(Assembly asm)
        {
            using (IUpgradeableLockHolder locker = internalsVisibleToDynamicProxyLock.ForReadingUpgradeable())
            {
                if(internalsVisibleToDynamicProxy.ContainsKey(asm))
                {
                    return internalsVisibleToDynamicProxy[asm];
                }

                locker.Upgrade();

                if(internalsVisibleToDynamicProxy.ContainsKey(asm))
                {
                    return internalsVisibleToDynamicProxy[asm];
                }

                IEnumerable<InternalsVisibleToAttribute> internalsVisibleTo = asm.GetCustomAttributes<InternalsVisibleToAttribute>();
                bool found = internalsVisibleTo.Any(attr => attr.AssemblyName.Contains(ModuleScope.DEFAULT_ASM_NAME));

                internalsVisibleToDynamicProxy.Add(asm, found);
                return found;
            }
        }
    }
}

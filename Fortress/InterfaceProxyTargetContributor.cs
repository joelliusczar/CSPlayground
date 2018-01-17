using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class InterfaceProxyTargetContributor: CompositeTypeContributor
    {
        private readonly bool canChangeTarget;
        private readonly Type proxyTargetType;

        public InterfaceProxyTargetContributor(Type proxyTargetType, bool canChangeTarget,INamingScope namingScope)
            :base(namingScope)
        {
            this.proxyTargetType = proxyTargetType;
            this.canChangeTarget = canChangeTarget;
        }
    }
}

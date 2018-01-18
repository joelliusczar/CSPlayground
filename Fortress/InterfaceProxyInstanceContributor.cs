using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class InterfaceProxyInstanceContributor: ProxyInstanceContributor
    {
        public InterfaceProxyInstanceContributor(Type targetType,string proxyGeneratorId, Type[] interfaces)
            :base(targetType,interfaces,proxyGeneratorId)
        { }
    }
}

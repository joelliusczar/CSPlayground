using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class DefaultProxyBuilder: IProxyBuilder
    {
        private readonly ModuleScope scope;

        public DefaultProxyBuilder()
            :this(new ModuleScope())
        { }

        public DefaultProxyBuilder(ModuleScope scope)
        {
            this.scope = scope;
        }

        public Type CreateInterfaceProxyTypeWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
        {
            InterfaceProxyWithoutTargetGenerator generator = new InterfaceProxyWithoutTargetGenerator(scope, interfaceToProxy);

        }
    }
}

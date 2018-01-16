using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class InterfaceProxyWithTargetInterfaceGenerator: InterfaceProxyWithTargetGenerator
    {
        public InterfaceProxyWithTargetInterfaceGenerator(ModuleScope scope, Type @interface)
            :base(scope,@interface)
        { }


    }
}

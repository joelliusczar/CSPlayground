using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class InterfaceProxyWithoutTargetGenerator: InterfaceProxyWithTargetGenerator
    {
        public InterfaceProxyWithoutTargetGenerator(ModuleScope scope, Type @interface)
            :base(scope,@interface)
        { }
    }
}

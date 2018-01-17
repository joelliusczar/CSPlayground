using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class InterfaceProxyWithoutTargetContributor: CompositeTypeContributor
    {
        private readonly GetTargetExpressionDelegate getTargetExpression;

        protected bool canChangeTarget = false;

        public InterfaceProxyWithoutTargetContributor(INamingScope namingScope, GetTargetExpressionDelegate getTarget)
            :base(namingScope)
        {
            this.getTargetExpression = getTarget;
        }
    }
}

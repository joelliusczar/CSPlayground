using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace Fortress
{
    public delegate EmExpression GetTargetExpressionDelegate(ClassEmitter @class, MethodInfo method);
}

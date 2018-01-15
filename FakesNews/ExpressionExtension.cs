using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace FakesNews
{
    public static class ExpressionExtension
    {
        public static (Expression Expr, MethodInfo Method,Expression[] Arguments) GetCallInfo(this LambdaExpression expression, FakeNews fake)
        {
            MethodCallExpression methodCall = expression.ToMethodCall();
            return (Expr: methodCall, Method: methodCall.Method, Arguments: methodCall.Arguments.ToArray());
        }

        public static MethodCallExpression ToMethodCall(this LambdaExpression expression)
        {
            MethodCallExpression methodCall = expression.Body as MethodCallExpression;
            return methodCall;
        }

        public static Expression PartialEval(this Expression expresso)
        {
            return Evaluator.PartialEval(expresso);
        }
    }
}

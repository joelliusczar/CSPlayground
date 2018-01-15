using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace FakesNews
{
    public class FakeNews
    {

        public DefaultValueProvider DefaultValueProvider { get; set; }
        public FakeBehavior behavior { get; set; }
        public static MustardCallReturn<T, TResult> Setup<T, TResult>(FakeNews<T> fake, Expression<Func<T, TResult>> expresso, Condition condition)
        {
            return AnotherNeedlessLayer.CallSomething(SetupNeedlessLayerStuff, fake, expresso, condition);
        }

        private static MustardCallReturn<T, TResult> SetupNeedlessLayerStuff<T, TResult>(FakeNews<T> fake, Expression<Func<T, TResult>> expresso, Condition condition)
        {
            (Expression expr,MethodInfo method,Expression[] args) = expresso.GetCallInfo(fake);

            MustardCallReturn<T, TResult> setup = new MustardCallReturn<T, TResult>(fake,condition,expresso,method,args);



            return setup;
        }

        private static FakeNews GetTargetNews(Expression smoothExpression,FakeNews fake)
        {
            if(smoothExpression is ParameterExpression)
            {
                return fake;
            }

            Expression targetExpr = SmoothFakeNewsVisitor.Accept(smoothExpression, fake);
            Expression<Func<FakeNews>> targetLambda = Expression.Lambda<Func<FakeNews>>(Expression.Convert(targetExpr, typeof(FakeNews)));

            FakeNews targetObject = targetLambda.Compile()();

            return targetObject;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FakesNews
{
    public static class MatcherFactory
    {
        public static IMatcher CreateMatcher(Expression expression, bool isParams)
        {
            Expression ogExpression = expression;
            if(expression.NodeType == ExpressionType.Convert)
            {
                expression = ((UnaryExpression)expression).Operand;
            }

            MatchExpression matchExpression = expression as MatchExpression;
            if(matchExpression != null)
            {
                return matchExpression.Match;
            }

            if(expression.NodeType == ExpressionType.Call)
            {
                MethodCallExpression call = (MethodCallExpression)expression;

                using (SmoothContext context = new SmoothContext())
                {
                    Expression.Lambda<Action>(call).Compile().Invoke();
                    if (context.LastMatch != null)
                    {
                        return context.LastMatch;
                    }

                }

                {
                    return new SlothfulEvalMatcher(ogExpression);
                }

            }
            else if(expression.NodeType == ExpressionType.MemberAccess)
            {
                using(SmoothContext context = new SmoothContext()) 
                {
                    Expression.Lambda<Action>((MemberExpression)expression).Compile().Invoke();
                    if(context.LastMatch != null)
                    {
                        return context.LastMatch;
                    }
                }
            }

            Expression reduced = ogExpression.PartialEval();
            if(reduced.NodeType == ExpressionType.Constant)
            {
                return new ConstantMatcher(((ConstantExpression)reduced).Value);
            }


            if(reduced.NodeType == ExpressionType.Quote)
            {
                return new ExpressionMatcher(((UnaryExpression)expression).Operand);
            }

            throw new NotSupportedException();
        }
    }
}

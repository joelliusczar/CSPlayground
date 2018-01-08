using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CSPlayground
{
    public class Expressionisto
    {
        public static void ExpressIt()
        {
            FibonacciExpressionTree();
        }

        private static void IncrementExpression()
        {
            ParameterExpression i = Expression.Variable(typeof(int), "i");
            BinaryExpression assign_i = Expression.Assign(i, Expression.Constant(0));

            int result = Expression.Lambda<Func<int>>(Expression.Block(new ParameterExpression[] { i }, assign_i, Expression.PreIncrementAssign(i), i)).Compile()();
            Console.WriteLine(result);
        }

        private static void FibonacciExpressionTree()
        {
            LabelTarget label = Expression.Label();
            LabelTarget returnLbl = Expression.Label(typeof(int));
            ParameterExpression input = Expression.Parameter(typeof(int), "input");
            ParameterExpression a = Expression.Variable(typeof(int), "a");
            ParameterExpression b = Expression.Variable(typeof(int), "b");
            ParameterExpression c = Expression.Variable(typeof(int), "c");

            BinaryExpression assign_a = Expression.Assign(a, Expression.Constant(0));
            BinaryExpression assign_b = Expression.Assign(b, Expression.Constant(0));
            BinaryExpression assign_c = Expression.Assign(c, Expression.Constant(1));


            ParameterExpression i = Expression.Variable(typeof(int), "i");
            BinaryExpression assign_i = Expression.Assign(i, Expression.Constant(0));
            BlockExpression loopBody = Expression.Block(
                Expression.Assign(b, a),
                Expression.Assign(a, c),
                Expression.Assign(c, Expression.Add(a, b)));
            BinaryExpression compareExp = Expression.LessThan(i, input);
            ConditionalExpression loopBranch = Expression.IfThenElse(
                compareExp,
                Expression.Block(Expression.PreIncrementAssign(i), loopBody),
                Expression.Break(label));
            LoopExpression fullLoop = Expression.Loop(loopBranch, label);
            BlockExpression blck = Expression.Block(new ParameterExpression[] { a, b, c, i }, assign_a, assign_b, assign_c, assign_i, fullLoop, a);
            foreach (Expression expr in blck.Expressions)
            {
                Console.WriteLine(expr.ToString());
            }
            int result = Expression.Lambda<Func<int, int>>(blck, input).Compile()(7);
            Console.WriteLine("Result is " + result);
        }

        private static void ExpressionHelloWorld()
        {
            ConstantExpression constExp = Expression.Constant("Hello World");
            MethodCallExpression callExp = Expression.Call(typeof(Expressionisto).GetMethod("WrapPrint", new Type[] { typeof(string) }), constExp);

            Action a = Expression.Lambda<Action>(callExp, null).Compile();
            a();
            Console.WriteLine(callExp.ToString());
        }

        public static void WrapPrint(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CSPlayground
{
    internal class ExpService
    {
        public string Name { get; set; }

        public string Namespace { get; set; }
    }

    public class Expressionisto
    {
        public static void ExpressIt()
        {

            FibonacciExpressionTree();
            //TorbjornsOtherExample();

        }

        private static void PrimitiveTorbjorns()
        {
            Expression<Func<int, int>> sel1 = s => s * 2;
            Expression<Func<int, int>> sel2 = s => s * 3;

            ConstantExpression val1 = Expression.Constant(4);
            ConstantExpression val2 = Expression.Constant(6);

            Expression e1 = Expression.Equal(sel1.Body, val1);
            Expression e2 = Expression.Equal(sel2.Body, val2);
            BinaryExpression andExp = Expression.AndAlso(e1, e2);

            ParameterExpression argParam = Expression.Parameter(typeof(int), "s");
            Expression<Func<int, bool>> callBack = Expression.Lambda<Func<int, bool>>(andExp, argParam);
            bool result = callBack.Compile()(2);
            Console.WriteLine(result);
        }

        private static void TorbjornsOtherExample()
        {
            Expression<Func<ExpService, string>> sel1 = s => s.Name;
            Expression<Func<ExpService, string>> sel2 = s => s.Namespace;

            ConstantExpression val1 = Expression.Constant("Modules");
            ConstantExpression val2 = Expression.Constant("Namespace");

            Expression e1 = Expression.Equal(sel1.Body, val1);
            Expression e2 = Expression.Equal(sel2.Body, val2);
            BinaryExpression andExp = Expression.AndAlso(e1, e2);

            ParameterExpression argParam = Expression.Parameter(typeof(ExpService), "s");
            Expression<Func<ExpService, bool>> callBack = Expression.Lambda<Func<ExpService, bool>>(andExp, argParam);

            bool result = callBack.Compile()(new ExpService() { Name = "a", Namespace = "B" }); ;
            Console.WriteLine(result);
        }

        private static void InvokeStuff()
        {
            Expression<Func<int, int>> square = num => num * num;
            InvocationExpression invoked = Expression.Invoke(square, Expression.Constant(3));
            var result = Expression.Lambda<Func<int>>(invoked).Compile()();

            Console.WriteLine(result);
        }

        private static void TorbjornsCode()
        {
            Expression<Func<ExpService, string>> sel1 = s => s.Name;
            Expression<Func<ExpService, string>> sel2 = srv => srv.Namespace;

            ConstantExpression val1 = Expression.Constant("Modules");
            ConstantExpression val2 = Expression.Constant("Namespace");

            Expression<Func<ExpService, bool>> lambda = m => true;

            ParameterExpression modelParameter = lambda.Parameters.First();

            {
                InvocationExpression invokedExpr = Expression.Invoke(sel1, modelParameter);
                BinaryExpression binaryExpression = Expression.Equal(invokedExpr, val1);
                lambda = Expression.Lambda<Func<ExpService, bool>>(Expression.AndAlso(binaryExpression, lambda.Body), lambda.Parameters);
            }

            {
                InvocationExpression invokedExpr = Expression.Invoke(sel2, modelParameter);
                BinaryExpression binaryExpression = Expression.Equal(invokedExpr, val2);
                lambda = Expression.Lambda<Func<ExpService, bool>>(Expression.AndAlso(binaryExpression, lambda.Body), lambda.Parameters);
            }
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

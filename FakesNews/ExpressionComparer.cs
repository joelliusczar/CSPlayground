using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FakesNews
{
    class ExpressionComparer: IEqualityComparer<Expression>
    {
        public static readonly ExpressionComparer Default = new ExpressionComparer();

        private ExpressionComparer()
        { }

        public bool Equals(Expression x, Expression y)
        {
            if(x == null && y == null)
            {
                return true;
            }

            if(x == null || y == null)
            {
                return false;
            }

            if(x.NodeType == y.NodeType)
            {
                switch(x.NodeType)
                {
                    case ExpressionType.Negate:
                    case ExpressionType.NegateChecked:
                    case ExpressionType.Not:
                    case ExpressionType.Convert:
                    case ExpressionType.ConvertChecked:
                    case ExpressionType.ArrayLength:
                    case ExpressionType.Quote:
                    case ExpressionType.TypeAs:
                    case ExpressionType.UnaryPlus:
                        return this.EqualsUnary((UnaryExpression)x, (UnaryExpression)y);
                    case ExpressionType.Add:
                    case ExpressionType.AddChecked:
                    case ExpressionType.Subtract:
                    case ExpressionType.SubtractChecked:
                    case ExpressionType.Multiply:
                    case ExpressionType.MultiplyChecked:
                    case ExpressionType.Divide:
                    case ExpressionType.Modulo:
                    case ExpressionType.And:
                    case ExpressionType.AndAlso:
                    case ExpressionType.Or:
                    case ExpressionType.OrElse:
                    case ExpressionType.LessThan:
                    case ExpressionType.LessThanOrEqual:
                    case ExpressionType.GreaterThan:
                    case ExpressionType.GreaterThanOrEqual:
                    case ExpressionType.Equal:
                    case ExpressionType.NotEqual:
                    case ExpressionType.Coalesce:
                    case ExpressionType.ArrayIndex:
                    case ExpressionType.RightShift:
                    case ExpressionType.LeftShift:
                    case ExpressionType.ExclusiveOr:
                    case ExpressionType.Power:
                        return EqualsBinary((BinaryExpression)x, (BinaryExpression)y);
                    case ExpressionType.TypeIs:
                        return this.EqualsTypeIsBinary((TypeBinaryExpression)x, (TypeBinaryExpression)y);
                    case ExpressionType.Conditional:
                        return this.EqualsConditional((ConditionalExpression)x, (ConditionalExpression)y);
                    case ExpressionType.Constant:
                        return this.EqualsConstant((ConstantExpression)x, (ConstantExpression)y);
                    case ExpressionType.Parameter:
                        return this.EqualsParameter((ParameterExpression)x,(ParameterExpression)y);
                    case ExpressionType.MemberAccess:
                        return this.EqualsMember((MemberExpression)x,(MemberExpression)y);
                    case ExpressionType.Call:
                        return this.EqualsMethodCall((MethodCallExpression)x, (MethodCallExpression)y);
                    case ExpressionType.Lambda:
                        return this.EqualsLambda((LambdaExpression)x, (LambdaExpression)y);
                    case ExpressionType.New:
                        return this.EqualsNew((NewExpression)x, (NewExpression)y);
                    case ExpressionType.NewArrayInit:
                    case ExpressionType.NewArrayBounds:
                        return this.EqualsNewArray((NewArrayExpression)x, (NewArrayExpression)y);
                    case ExpressionType.Invoke:
                        return this.EqualsInvocation((InvocationExpression)x, (InvocationExpression)y);
                    case ExpressionType.MemberInit:
                        return this.EqualsMemberInit((MemberInitExpression)x, (MemberInitExpression)y);
                    case ExpressionType.ListInit:
                        return this.EqualsListInit((ListInitExpression)x, (ListInitExpression)y);

                }
            }

            return false;
        }

        public int GetHashCode(Expression obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }

        private static bool Equals<T>(ReadOnlyCollection<T> x,ReadOnlyCollection<T> y,Func<T,T,bool> comparer)
        {
            if(x.Count != y.Count)
            {
                return false;
            }

            for(int i = 0;i < x.Count;i++)
            {
                if(!comparer(x[i],y[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool EqualsBinary(BinaryExpression x,BinaryExpression y)
        {
            return x.Method == y.Method && this.Equals(x.Left, y.Left) && this.Equals(x.Right, y.Right)
                && this.Equals(x.Conversion, y.Conversion);
        }

        private bool EqualsUnary(UnaryExpression x,UnaryExpression y)
        {
            return x.Method == y.Method && this.Equals(x.Operand, y.Operand);
        }

        private bool EqualsTypeIsBinary(TypeBinaryExpression x,TypeBinaryExpression y)
        {
            return x.TypeOperand == y.TypeOperand && this.Equals(x.Expression, y.Expression);
        }

        private bool EqualsConditional(ConditionalExpression x,ConditionalExpression y)
        {
            return this.Equals(x.Test, y.Test) && this.Equals(x.IfTrue, y.IfTrue) && this.Equals(x.IfFalse, y.IfFalse);
        }

        private bool EqualsConstant(ConstantExpression x,ConstantExpression y)
        {
            return object.Equals(x.Value, y.Value);
        }

        private bool EqualsParameter(ParameterExpression x,ParameterExpression y)
        {
            return x.Type == y.Type;
        }

        private bool EqualsMember(MemberExpression x,MemberExpression y)
        {
            return x.Member == y.Member && this.Equals(x.Expression, y.Expression);
        }

        private bool EqualsMethodCall(MethodCallExpression x,MethodCallExpression y)
        {
            return x.Method == y.Method && this.Equals(x.Object, y.Object)
                && Equals(x.Arguments, y.Arguments);
        }

        private bool EqualsLambda(LambdaExpression x,LambdaExpression y)
        {
            return x.GetType() == y.GetType() && this.Equals(x.Body, y.Body)
                && Equals(x.Parameters, y.Parameters, this.EqualsParameter); 
        }

        private bool EqualsNew(NewExpression x,NewExpression y)
        {
            return x.Constructor == y.Constructor && Equals(x.Arguments, y.Arguments, this.Equals);
        }

        private bool EqualsNewArray(NewArrayExpression x,NewArrayExpression y)
        {
            return x.Type == y.Type && Equals(x.Expressions, y.Expressions, this.Equals);
        }

        private bool EqualsInvocation(InvocationExpression x,InvocationExpression y)
        {
            return this.Equals(x.Expression, y.Expression) && Equals(x.Arguments, y.Arguments, this.Equals);
        }

        private bool EqualsMemberBinding(MemberBinding x, MemberBinding y)
        {
            if(x.BindingType == y.BindingType && x.Member == y.Member)
            {
                switch(x.BindingType)
                {
                    case MemberBindingType.Assignment:
                        return EqualsMemberAssignment((MemberAssignment)x, (MemberAssignment)y);
                    case MemberBindingType.MemberBinding:
                        return this.EqualsMemberMemberBinding((MemberMemberBinding)x,(MemberMemberBinding)y);
                    case MemberBindingType.ListBinding:
                        return this.EqualsMemberListBinding((MemberListBinding)x, (MemberListBinding)y);
                }

            }
            return false;
        }

        private bool EqualsMemberAssignment(MemberAssignment x,MemberAssignment y)
        {
            return this.Equals(x.Expression, y.Expression);
        }

        private bool EqualsMemberMemberBinding(MemberMemberBinding x,MemberMemberBinding y)
        {
            return Equals(x.Bindings, y.Bindings, this.EqualsMemberBinding);
        }

        private bool EqualsMemberListBinding(MemberListBinding x, MemberListBinding y)
        {
            return Equals(x.Initializers, y.Initializers, this.EqualsElementInit);
        }

        private bool EqualsElementInit(ElementInit x, ElementInit y)
        {
            return x.AddMethod == y.AddMethod && Equals(x.Arguments, y.Arguments, this.Equals);
        }

        private bool EqualsMemberInit(MemberInitExpression x,MemberInitExpression y)
        {
            return this.EqualsNew(x.NewExpression, y.NewExpression)
                && Equals(x.Bindings, y.Bindings, this.EqualsMemberBinding);
        }

        private bool EqualsListInit(ListInitExpression x,ListInitExpression y)
        {
            return Equals(x.Initializers, y.Initializers, this.EqualsElementInit);
        }

    }
}

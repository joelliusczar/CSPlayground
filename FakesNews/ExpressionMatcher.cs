using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FakesNews
{
    public class ExpressionMatcher: IMatcher
    {
        private Expression _expression;

        public ExpressionMatcher(Expression expresso)
        {
            this._expression = expresso;
        }

        public bool Matches(object value)
        {
            return value is Expression valueExpression
                && ExpressionComparer.Default.Equals(this._expression, valueExpression);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FakesNews
{
    public class SlothfulEvalMatcher
    {
        private Expression _expresso;

        public SlothfulEvalMatcher(Expression expresso)
        {
            this._expresso = expresso;
        }

        public bool Matches(object value)
        {
            Expression eval = Evaluator.PartialEval(this._expresso);
            if(eval.NodeType == ExpressionType.Constant)
            {
                return object.Equals(((ConstantExpression)eval).Value, value);
            }

            return false;
        }
    }
}

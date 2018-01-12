using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FakesNews
{
    public static class Evaluator
    {

        public static Expression PartialEval(Expression expresso)
        {

        }
    }

    public class SubTreeEvaluator: ExpressionVisitor
    {
        private HashSet<Expression> _candidates;

        public SubTreeEvaluator(HashSet<Expression> candidates)
        {
            this._candidates = candidates;
        }
    }

    public class Nominator: ExpressionVisitor
    {
        private bool _cannotBeEvaluated;
        private Func<Expression, bool> _fnCanBeEvaluated;
        private HashSet<Expression> _candidates;

        public Nominator(Func<Expression,bool> fnCanBeEvaluated)
        {
            this._fnCanBeEvaluated = fnCanBeEvaluated;
        }

        public HashSet<Expression> Nominate(Expression expresso)
        {
            this._candidates = new HashSet<Expression>();
            this.Visit(expresso);
            return this._candidates;
        }
        public override Expression Visit(Expression expresso)
        {
            if(expresso != null)
            {
                bool saveCannotBeEvaluated = this._cannotBeEvaluated;
                this._cannotBeEvaluated = false;
                base.Visit(expresso);
                if(!this._cannotBeEvaluated)
                {
                    if(this._fnCanBeEvaluated(expresso))
                    {
                        this._candidates.Add(expresso); 
                    }
                    else
                    {
                        this._cannotBeEvaluated = true;
                    }

                }
                this._cannotBeEvaluated |= saveCannotBeEvaluated;
            }

            return expresso;
        }
    }
}

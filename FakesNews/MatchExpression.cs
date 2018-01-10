using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FakesNews
{
    public class MatchExpression: Expression
    {
        public Match Match { get; private set; }

        public MatchExpression(Match match)
        {
            this.Match = match;
        }

        public override ExpressionType NodeType
        {
            get { return ExpressionType.Call; }
        }

        public override Type Type
        {
            get { return typeof(Match); }
        }

    }
}

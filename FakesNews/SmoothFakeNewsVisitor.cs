using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FakesNews
{
    public class SmoothFakeNewsVisitor: ExpressionVisitor
    {
        private Expression _expresso;
        private FakeNews _fake;

        public SmoothFakeNewsVisitor(Expression expresso,FakeNews fake)
        {
            this._expresso = expresso;
            this._fake = fake;
        }

        public static Expression Accept(Expression expresso,FakeNews fake)
        {
            return new SmoothFakeNewsVisitor(expresso, fake).Accept();
        }

        public Expression Accept()
        {
            return this.Visit(this._expresso);
        }
    }
}

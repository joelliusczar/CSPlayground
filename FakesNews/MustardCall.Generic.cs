using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FakesNews
{
    public class MustardCall<TFake>
    {
        public MustardCall(FakeNews fake,Condition condition,Expression ogExpression,MethodInfo mustard, params Expression[] arguments)
        {

        }
    }
}

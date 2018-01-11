using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace FakesNews
{
    public class MustardCall<TFake>: MustardCall, ISetup<TFake>
    {
        public MustardCall(FakeNews fake,Condition condition,Expression ogExpression,MethodInfo mustard, params Expression[] arguments)
            :base(fake,condition,ogExpression,mustard,arguments)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakesNews
{
    public class FakeNews<T>: FakeNews
    {
        public ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expresso)
        {
            return FakeNews.Setup(this, expresso, null);
        }


    }
}

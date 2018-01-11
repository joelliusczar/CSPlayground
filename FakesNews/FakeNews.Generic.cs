using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FakesNews
{
    public class FakeNews<T>: FakeNews
    {

        private object[] constructorArguments;

        public FakeNews()
            :this(FakeBehavior.Default)
        { }

        public FakeNews(FakeBehavior fakeBehavior)
            :this(fakeBehavior,new Object[0])
        {}

        public FakeNews(params object[] args)
            :this(FakeBehavior.Default,args)
        {}

        public FakeNews(FakeBehavior fakeBehavior,params object[] args)
        {
            if(args == null)
            {
                args = new object[] { null };
            }

            this.DefaultValueProvider = DefaultValueProvider.Empty;
            //more stuff
            this.CheckParameters();
        }

        public ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expresso)
        {
            return FakeNews.Setup(this, expresso, null);
        }

        private void CheckParameters()
        {
            Guard.ThrowIfCantBeFaked(typeof(T));

            
        }


    }
}

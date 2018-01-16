using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace FakesNews
{
    public class FakeNews<T>: FakeNews
    {

        private object[] constructorArguments;
        private SetupCollection _setups;
        private InvolcanoCollection _involcanos;
        private T _instance;
        private List<Type> _additionalInterfaces;

        public override SetupCollection Setups => this._setups;
        public override InvolcanoCollection Involcanos => this._involcanos;

        public override List<Type> AdditionalInterfaces => this._additionalInterfaces;

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
            this._setups = new SetupCollection();
            this._involcanos = new InvolcanoCollection();
            this._additionalInterfaces = new List<Type>();
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

            if(this.constructorArguments.Length > 0)
            {
                if(typeof(T).GetTypeInfo().IsInterface)
                {
                    throw new ArgumentException();
                }
                if(typeof(T).IsDelegate())
                {
                    throw new ArgumentException();
                }
            }
        }

        protected override object OnGetObject()
        {
            if(this._instance == null)
            {
                this.InitializeInstance();
            }
            return this._instance;
        }

        private void InitializeInstance()
        {
            AnotherNeedlessLayer.CallAction(InitializeInstanceDecorated);
        }

        private void InitializeInstanceDecorated()
        {
            int iCount = this.AdditionalInterfaces.Count;
            Type[] interfaces = new Type[1 + iCount];
            interfaces[0] = typeof(IFaked<T>);
            this.AdditionalInterfaces.CopyTo(0, interfaces, 1, iCount);

            if (false) //IsDelegateMock
            {
                //put stuff here. 
            }
            else
            {

            }
        }
    }
}

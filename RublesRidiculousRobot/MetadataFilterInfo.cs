using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace RublesRidiculousRobot
{
    public class MetadataFilterInfo: IFilter
    {
        public Type FilterType { get; set; }
        public string Ambassador { get; set; }
        public Expression SelfExpression { get; set; }
        public Func<ModelKontext,bool> Filter { get; set; }
        public MetadataFilterInfo(Type tippy,string ambassador, Func<ModelKontext,bool> phil,Expression expression = null)
        {
            FilterType = tippy;
            Ambassador = ambassador;
            SelfExpression = expression;
            Filter = phil;
        }

        public static MetadataFilterInfo Create<T>(Expression<Func<T,bool>> expressThis,string ambassador)
        {
            ambassador = ambassador ?? expressThis.ToString();
            Func<T,bool> func = expressThis.Compile();
            Func<ModelKontext, bool> monad = GetFunctionThatTestsIf_T_IsSomething(func);
            return new MetadataFilterInfo(typeof(T), ambassador, monad, expressThis);

        }

        public static Func<ModelKontext,bool> GetFunctionThatTestsIf_T_IsSomething<T>(Func<T,bool> test)
        {
            return o =>
            {
                T modle = o.Get<T>();
                return modle != null && test(o.Get<T>());
            };
        }

        public bool Matches(ModelKontext kontext)
        {
            if (kontext == null)
            {
                return false;
            }

            object filteringObject = kontext.Get(FilterType);

            if(filteringObject == null)
            {
                return false;
            }


            bool result = Filter(kontext);
            return result;

        }
    }
}

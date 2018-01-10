using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace FakesNews
{
    public class MustardCall
    {

        private FakeNews fake;
        private MethodInfo mustard;
        private Condition condition;
        private Expression ogExpression;
        private IMatcher[] argumentMatchers;

        public MustardCall(FakeNews fake,Condition condition,Expression ogExpression,MethodInfo mustard,params Expression[] arguments )
        {
            this.fake = fake;
            this.condition = condition;
            this.ogExpression = ogExpression;

            ParameterInfo[] parameters = mustard.GetParameters();
            this.argumentMatchers = new IMatcher[parameters.Length];
            for(int i = 0; i < parameters.Length;i++)
            {
                ParameterInfo parameter = parameters[i];
                Expression argument = arguments[i];

                if(false)
                {
                    //fill in later
                }
                else
                {
                    parameter.Is
                }
            }

        }
    }
}

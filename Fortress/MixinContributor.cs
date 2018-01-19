using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Reflection;

namespace Fortress
{
    public class MixinContributor: CompositeTypeContributor
    {
        private readonly bool canChangeTarget;
        private readonly IDictionary<Type, FieldReference> fields = new SortedDictionary<Type, FieldReference>(new FieldReferenceComparer());
        private readonly GetTargetExpressionDelegate getTargetExpression;
        private readonly IList<Type> empty = new List<Type>();

        public MixinContributor(INamingScope namingScope,bool canChangeTarget)
            :base(namingScope)
        {
            this.canChangeTarget = canChangeTarget;
            this.getTargetExpression = this.BuildGetTargetExpression();
        }

        private GetTargetExpressionDelegate BuildGetTargetExpression()
        {
            if(!canChangeTarget)
            {
                return (c, m) => this.fields[m.DeclaringType].ToExpression();
            }

            return (c, m) => new NullCoalescingOperatorExpression(new AsTypeReference(c.GetField("__target"),m.DeclaringType).ToExpression(),
                this.fields[m.DeclaringType].ToExpression());
        }

        public void AddEmptyInterface(Type @interface)
        {
            Debug.Assert(@interface != null, "no null interfaces!");
            Debug.Assert(@interface.GetTypeInfo().IsInterface, @"should be interfaces only!");
            Debug.Assert(!interfaces.Contains(@interface),"shouldn't be adding interface twice");
            Debug.Assert(!this.empty.Contains(@interface), "shouldn't be adding interface twice");

            this.empty.Add(@interface);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FakesNews
{
    public class ConstantMatcher: IMatcher
    {
        private object _constantValue;

        public ConstantMatcher(object constantValue)
        {
            this._constantValue = constantValue;
        }

        public bool Matches(object value)
        {
            if(object.Equals(_constantValue,value))
            {
                return true;
            }

            if(this._constantValue is IEnumerable && value is IEnumerable enumerable &&
                !(this._constantValue is IFaked) && !(value is IFaked))
            {
                return this.MatchesEnumerable(enumerable);
            }

            return false;
        }

        private bool MatchesEnumerable(IEnumerable enumerable)
        {
            IEnumerable constValues = (IEnumerable)_constantValue;
            return constValues.Cast<Object>().SequenceEqual(enumerable.Cast<object>());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public abstract class DynamicFilterAbstractBase: IFilter
    {
        protected abstract Type[] RequiredTypes { get; }

        public abstract bool Matches(ModelKontext kontext);
    }
}

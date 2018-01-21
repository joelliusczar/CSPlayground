using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public abstract class MetaTypeElement
    {
        protected readonly Type sourceType;

        protected MetaTypeElement(Type sourceType)
        {
            this.sourceType = sourceType;
        }

        public bool CanBeImplementedExplicitly
        {
            get { return this.sourceType != null && sourceType.GetTypeInfo().IsInterface; }
        }

        public abstract void SwitchToExplicitImplementation();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace FakesNews
{
    public class SetupCollection
    {
        private Stack<MustardCall> _setups;

        public SetupCollection()
        {
            this._setups = new Stack<MustardCall>();
        }

        public void Add(MustardCall setup)
        {
            lock(this._setups)
            {
                this._setups.Push(setup);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakesNews
{
    public class SmoothContext: IDisposable
    {
        [ThreadStatic]
        private static SmoothContext _current;

        public static SmoothContext Current
        {
            get { return Current; }
        }

        public SmoothContext()
        {
            _current = this;
        }

        public void Dispose()
        {

        }
    }

    public class FakeInvocation: IDisposable
    {
        private Def
    }
}

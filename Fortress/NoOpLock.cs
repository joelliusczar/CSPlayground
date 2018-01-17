using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class NoOpLock: ILockHolder
    {
        public static readonly ILockHolder Lock = new NoOpLock();

        public void Dispose()
        { }

        public bool LockAcquired
        {
            get { return true; }
        }
    }
}

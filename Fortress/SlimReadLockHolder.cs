using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fortress
{
    public class SlimReadLockHolder: ILockHolder
    {
        private readonly ReaderWriterLockSlim locker;
        private bool lockAcquired;

        public SlimReadLockHolder(ReaderWriterLockSlim locker, bool waitForLock)
        {
            this.locker = locker;
            if(waitForLock)
            {
                this.locker.EnterReadLock();
                this.lockAcquired = true;
                return;
            }
            this.lockAcquired = locker.TryEnterReadLock(0);
        }

        public void Dispose()
        {
            if (!this.LockAcquired)
            {
                return;
            }
            this.locker.ExitReadLock();
            this.lockAcquired = false;
        }

        public bool LockAcquired
        {
            get { return this.lockAcquired; }
        }
    }
}

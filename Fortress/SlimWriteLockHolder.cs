using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fortress
{
    public class SlimWriteLockHolder: ILockHolder
    {
        private readonly ReaderWriterLockSlim locker;

        private bool lockAcquired;

        public SlimWriteLockHolder(ReaderWriterLockSlim locker, bool waitForLock)
        {
            this.locker = locker;
            if(waitForLock)
            {
                this.locker.EnterWriteLock();
                this.lockAcquired = true;
                return;
            }
            this.lockAcquired = locker.TryEnterWriteLock(0);
        }


        public void Dispose()
        {
            if(!this.LockAcquired)
            {
                return;
            }
            locker.ExitWriteLock();
            this.lockAcquired = false;
        }

        public bool LockAcquired
        {
            get { return this.lockAcquired; }
        }
    }
}

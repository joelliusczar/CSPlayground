using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fortress
{
    public class SlimUpgradeableReadLockHolder: IUpgradeableLockHolder
    {
        private readonly ReaderWriterLockSlim locker;
        private bool lockAcquired;
        private SlimWriteLockHolder writerLock;
        private bool wasLockAlreadyHeld;

        public SlimUpgradeableReadLockHolder(ReaderWriterLockSlim locker,bool waitForLock,bool wasLockAlreadyHeld)
        {
            this.locker = locker;
            if(wasLockAlreadyHeld)
            {
                this.lockAcquired = true;
                this.wasLockAlreadyHeld = true;
                return;
            }

            if(waitForLock)
            {
                locker.EnterUpgradeableReadLock();
                this.lockAcquired = true;
                return;
            }

            this.lockAcquired = locker.TryEnterUpgradeableReadLock(0);
        }

        public void Dispose()
        {
            if(this.writerLock != null && this.writerLock.LockAcquired)
            {
                writerLock.Dispose();
                writerLock = null;
            }
            if(!this.LockAcquired)
            {
                return;
            }
            if(!this.wasLockAlreadyHeld)
            {
                this.locker.ExitUpgradeableReadLock();
            }
            this.lockAcquired = false;

        }

        public ILockHolder Upgrade()
        {
            return Upgrade(true);
        }

        public ILockHolder Upgrade(bool waitForLock)
        {
            if(this.locker.IsWriteLockHeld)
            {
                return NoOpLock.Lock;
            }
            this.writerLock = new SlimWriteLockHolder(this.locker, waitForLock);
            return this.writerLock;
        }

        public bool LockAcquired
        {
            get { return this.lockAcquired;  }
        }
    }
}

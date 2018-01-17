using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fortress
{
    public class SlimReadWriteLock: Lock
    {

        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        public override ILockHolder ForReading()
        {
            return this.ForReading(true);
        }

        public override ILockHolder ForReading(bool waitForLock)
        {
            if(this.locker.IsReadLockHeld || this.locker.IsUpgradeableReadLockHeld || this.locker.IsWriteLockHeld)
            {
                return NoOpLock.Lock;
            }

            return new SlimReadLockHolder(this.locker, waitForLock);
        }

        public override ILockHolder ForWriting()
        {
            return this.ForWriting(true);
        }


        public override ILockHolder ForWriting(bool waitForLock)
        {
            if(this.locker.IsWriteLockHeld)
            {
                return NoOpLock.Lock;
            }
            return new SlimWriteLockHolder(this.locker, waitForLock);
        }

        public override IUpgradeableLockHolder ForReadingUpgradeable()
        {
            return this.ForReadingUpgradeable();
        }

        public override IUpgradeableLockHolder ForReadingUpgradeable(bool waitForLock)
        {
            return new SlimUpgradeableReadLockHolder(this.locker,waitForLock,this.locker.IsUpgradeableReadLockHeld || this.locker.IsWriteLockHeld);
        }


    }
}

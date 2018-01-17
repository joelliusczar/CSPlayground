using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public abstract class Lock
    {
        public abstract IUpgradeableLockHolder ForReadingUpgradeable();
        public abstract ILockHolder ForReading();
        public abstract ILockHolder ForWriting();

        public abstract IUpgradeableLockHolder ForReadingUpgradeable(bool waitForLock);
        public abstract ILockHolder ForReading(bool waitForLock);
        public abstract ILockHolder ForWriting(bool waitForLock);

        public static Lock Create()
        {
            return new SlimReadWriteLock();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Autho.Services
{
    public static class StaticVars
    {

        public static readonly object LockOb = new object();
        public static readonly bool IsLocked = Monitor.IsEntered(LockOb);
        public static volatile bool IsReallyLocked = false;
    }
}
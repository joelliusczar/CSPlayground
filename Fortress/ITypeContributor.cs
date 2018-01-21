﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public interface ITypeContributor
    {
        void CollectElementsToProxy(IProxyGenerationHook hook, MetaType model);
    }
}

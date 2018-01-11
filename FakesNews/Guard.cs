using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakesNews
{
    public static class Guard
    {
        public static void ThrowIfCantBeFaked(Type type)
        {
            if(type.CanBeFaked())
            {
                throw new NotSupportedException();
            }
        }
    }
}

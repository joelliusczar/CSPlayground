using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPlayground
{
    class Ashtonishing: IMash, IBash, ITrash
    {
        void IMash.DoAshStuff()
        {
            Console.WriteLine("Hulk mash!");
        }

        void IBash.DoAshStuff()
        {
            Console.WriteLine("Hulk bash!");
        }

        void ITrash.DoAshStuff()
        {
            ((IMash)this).DoAshStuff();
        }
    }
}

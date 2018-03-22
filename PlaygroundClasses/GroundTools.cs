using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    class GroundTools: IDig
    {
        public Finger<int> GetTool()
        {
            return new Finger<int>();
        }

        object IDig.GetTool()
        {
            return this.GetTool();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class UselessAttribute: System.Attribute
    {
    }

    [System.AttributeUsage(System.AttributeTargets.All)]
    public class DumbAttribute: System.Attribute
    {
        public int TestValue { get; set; } 
    }

    [System.AttributeUsage(System.AttributeTargets.All)]
    public class AnOtroAttribute : System.Attribute
    {

    }
}

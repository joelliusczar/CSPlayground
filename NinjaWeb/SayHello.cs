using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjaWeb
{
    public class SayHello: ISay
    {
        public string Echo()
        {
            return "Hello!";
        }
    }
}
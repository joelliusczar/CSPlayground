using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autho.Models
{
    [Serializable]
    public class Ship
    {
        public string name { get; set; }
        public string CaptainName { get; set; }
        public string NumCannons { get; set; }

    }
}
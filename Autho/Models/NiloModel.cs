using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autho.Models
{
    public class NiloModel
    {
        public int WildNum { get; set; }
        
        [Required]
        public List<string> testList { get; set; }
    }
}
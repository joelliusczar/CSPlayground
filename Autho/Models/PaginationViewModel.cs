using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autho.Models
{
    public class PaginationViewModel
    {
        public int PageSize { get; set; }
        public int ItemCount { get; set; }
        public int VisibleLinkCount { get; set; }
        public int CurrentPageNum { get; set; }
        public Func<int,MvcHtmlString> BuildActionlink { get; set; }
    }
}
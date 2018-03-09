using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autho.Services
{
    public class TriumphHtmlHelpers
    {
        public static MvcHtmlString BootstapPaginate(string controller,string action,Func<int,object> routeValueBuilder,int? prev,int? next)
        {
            TagBuilder nav = new TagBuilder("nav");
            TagBuilder ul = new TagBuilder("ul");

            TagBuilder nextLink = new TagBuilder("li");
            return null;
        }
    }
}
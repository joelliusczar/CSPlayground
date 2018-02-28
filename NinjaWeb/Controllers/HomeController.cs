using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NinjaWeb.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "'sup world";
        }

        public ActionResult Chat()
        {
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autho.Models;

namespace Autho.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetFunky()
        {
            var js = new JSModel {
                jsFunc = "function(){alert(\"It's funky in here\")}"
            };
            return View("TryFunc", js);
        }

        public ActionResult Splatter()
        {
            var s = new SplatterPark {
                SplatCount = 11,
                SplatSoundDescription = "splort",
                IsSticky = true
            };
            return View(s);
        }
    }
}
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

        public ActionResult ChooseSplat()
        {
            var s = new WhichSplatter {
                Name = "Kevin",
                SplatChoices = new List<SplatterPark> {
                    new SplatterPark{ Id = 0, SplatCount = 3, SplatSoundDescription = "kadorsh",IsSticky = false},
                    new SplatterPark{ Id = 1, SplatCount = 5, SplatSoundDescription = "bayshak",IsSticky = false},
                    new SplatterPark{ Id = 2, SplatCount = 7, SplatSoundDescription = "barlorsk",IsSticky = false}
                },
                Mixins = new List<string> {
                    "tar",
                    "philbull",
                    "riula"
                },
                AreSplattered = new List<bool> {
                    true,
                    false,
                    true,
                }
            };

            return View(s);
        }

        [HttpPost]
        public void ChooseSplat(int? splatD)
        {
            ;
        }

        public void SplatBlitz()
        {
            ;
        }


        public void SplatCup()
        {
            ;
        }

        public void Splist(HashSet<string> zhech)
        {
            ;
        }
    }
}
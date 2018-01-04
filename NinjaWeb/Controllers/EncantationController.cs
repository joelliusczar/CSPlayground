using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NinjaWeb;

namespace NinjaWeb.Controllers
{
    public class EncantationController : Controller
    {
        private readonly ISay _speaker;
        public EncantationController(ISay speaker)
        {
            this._speaker = speaker;
        }

        // GET: Encantation
        public string Index()
        {
            return this._speaker.Echo();
        }
    }
}
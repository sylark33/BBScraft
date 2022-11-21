using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YiCraft.Controllers
{
    public class YiCraftController : Controller
    {
        // GET: YiCraft
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult File()
        {
            return View();
        }
    }
}
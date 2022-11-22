using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiCraft.Models;

namespace YiCraft.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login_end(string name, string pwd)
        {
            YiCraftCoreEntities2 yc = new YiCraftCoreEntities2();
            player_infos p = yc.player_infos.SingleOrDefault<player_infos>(n => n.uid == name);
            if (p.pwd == pwd)
            {
                Session["uid"] = name;
                return RedirectToAction("Index", "discuss_infos","登入成功！");
            }
            else
            {
                return Content("<script>alert('密码错误！');window.location.href='../Login/index';</script>");
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiCraft.Models;

namespace YiCraft.Controllers
{
    public class reply_infosController : Controller
    {
        private YiCraftCoreEntities2 db = new YiCraftCoreEntities2();
        // GET: reply_infos
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "reply")] reply_infos reply_Infos)
        {
            if (ModelState.IsValid && reply_Infos.reply != null)
            {
                reply_Infos.theme_id = Convert.ToInt32(Session["did"]);
                reply_Infos.ReplyAuthor = Session["uid"].ToString();
                reply_Infos.ReplyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                db.reply_infos.Add(reply_Infos);
                db.SaveChanges();
                if (Session["uid"].ToString() == "FYZY" && reply_Infos.reply.Contains("已解决"))
                {
                    var pm = from u in db.discuss_infos
                             where u.id ==reply_Infos.theme_id
                             select u;
                    discuss_infos di = new discuss_infos();
                    foreach (var k in pm)
                    {
                        di = (discuss_infos)k;
                    }
                    di.solve = "已解决";
                    db.Entry(di).State= EntityState.Modified;
                    db.Entry(di).Property(u => u.id).IsModified = true;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "discuss_infos", "创建成功");
            }
                return RedirectToAction("Index", "discuss_infos", "创建失败");
        }

      
    }
}
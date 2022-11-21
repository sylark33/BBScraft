using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YiCraft.Models;

namespace YiCraft.Controllers
{
    public class player_infosController : Controller
    {
        private YiCraftCoreEntities2 db = new YiCraftCoreEntities2();

        // GET: player_infos
        public ActionResult Index()
        {
            return View(db.player_infos.ToList());
        }

        // GET: player_infos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_infos player_infos = db.player_infos.Find(id);
            if (player_infos == null)
            {
                return HttpNotFound();
            }
            return View(player_infos);
        }

        // GET: player_infos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: player_infos/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,uid,pwd")] player_infos player_infos)
        {
            YiCraftCoreEntities2 yc = new YiCraftCoreEntities2();
            yicraft_infos y = yc.yicraft_infos.SingleOrDefault<yicraft_infos>(n => n.loginname == player_infos.uid);
            player_infos p=yc.player_infos.SingleOrDefault<player_infos>(n => n.uid == player_infos.uid);
            if (y == null)
            {
                return Content("<script>alert('注册失败！请确保你有白名单！');window.location.href='../Login/index';</script>");
            }
            else
            {
                if (ModelState.IsValid && p == null)
                {
                    db.player_infos.Add(player_infos);
                    db.SaveChanges();
                    return Content("<script>alert('恭喜注册成功！请登入！');window.location.href='../Login/index';</script>");
                }
                else
                {
                    return Content("<script>alert('注册失败！请确保你有白名单！');window.location.href='../Login/index';</script>");
                }
            }
        }

        // GET: player_infos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_infos player_infos = db.player_infos.Find(id);
            if (player_infos == null)
            {
                return HttpNotFound();
            }
            return View(player_infos);
        }

        // POST: player_infos/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,uid,pwd")] player_infos player_infos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player_infos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player_infos);
        }

        // GET: player_infos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player_infos player_infos = db.player_infos.Find(id);
            if (player_infos == null)
            {
                return HttpNotFound();
            }
            return View(player_infos);
        }

        // POST: player_infos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            player_infos player_infos = db.player_infos.Find(id);
            db.player_infos.Remove(player_infos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

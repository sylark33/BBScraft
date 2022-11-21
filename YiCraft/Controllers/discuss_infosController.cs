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
    public class discuss_infosController : Controller
    {
        private YiCraftCoreEntities2 db = new YiCraftCoreEntities2();

        // GET: discuss_infos
        public ActionResult Index()
        {
            return View(db.discuss_infos.ToList());
        }

        // GET: discuss_infos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discuss_infos discuss_infos = db.discuss_infos.Find(id);
            if (discuss_infos == null)
            {
                return HttpNotFound();
            }
            return View(discuss_infos);
        }

        // GET: discuss_infos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: discuss_infos/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,theme,AllContent,time,author")] discuss_infos discuss_infos)
        {

            if (ModelState.IsValid&&discuss_infos!=null&&discuss_infos.theme!=null)
            {
                discuss_infos.author = Session["uid"].ToString();
                discuss_infos.time= DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                discuss_infos.solve = "未解决";
                db.discuss_infos.Add(discuss_infos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discuss_infos);
        }

        // GET: discuss_infos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discuss_infos discuss_infos = db.discuss_infos.Find(id);
            if (discuss_infos == null)
            {
                return HttpNotFound();
            }
            return View(discuss_infos);
        }

        // POST: discuss_infos/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,theme,AllContent,time,author")] discuss_infos discuss_infos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discuss_infos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discuss_infos);
        }

        // GET: discuss_infos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discuss_infos discuss_infos = db.discuss_infos.Find(id);
            if (discuss_infos == null)
            {
                return HttpNotFound();
            }
            return View(discuss_infos);
        }

        // POST: discuss_infos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            discuss_infos discuss_infos = db.discuss_infos.Find(id);
            db.discuss_infos.Remove(discuss_infos);
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

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
    public class yicraft_infosController : Controller
    {
        private YiCraftCoreEntities2 db = new YiCraftCoreEntities2();

        // GET: yicraft_infos
        public ActionResult Index()
        {
            return View(db.yicraft_infos.ToList());
        }

        // GET: yicraft_infos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yicraft_infos yicraft_infos = db.yicraft_infos.Find(id);
            if (yicraft_infos == null)
            {
                return HttpNotFound();
            }
            return View(yicraft_infos);
        }

        // GET: yicraft_infos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: yicraft_infos/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,loginname,balance,status")] yicraft_infos yicraft_infos)
        {
            if (ModelState.IsValid)
            {
                db.yicraft_infos.Add(yicraft_infos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yicraft_infos);
        }

        // GET: yicraft_infos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yicraft_infos yicraft_infos = db.yicraft_infos.Find(id);
            if (yicraft_infos == null)
            {
                return HttpNotFound();
            }
            return View(yicraft_infos);
        }

        // POST: yicraft_infos/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,loginname,balance,status")] yicraft_infos yicraft_infos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yicraft_infos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yicraft_infos);
        }

        // GET: yicraft_infos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yicraft_infos yicraft_infos = db.yicraft_infos.Find(id);
            if (yicraft_infos == null)
            {
                return HttpNotFound();
            }
            return View(yicraft_infos);
        }

        // POST: yicraft_infos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yicraft_infos yicraft_infos = db.yicraft_infos.Find(id);
            db.yicraft_infos.Remove(yicraft_infos);
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

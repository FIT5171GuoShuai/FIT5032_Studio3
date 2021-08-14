using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FIT5032_MyJs.Models;

namespace FIT5032_MyJs.Controllers
{
    public class HeritagesController : Controller
    {
        private UserContainer db = new UserContainer();

        // GET: Heritages
        public ActionResult Index()
        {
            return View(db.HeritageSet.ToList());
        }

        // GET: Heritages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritage heritage = db.HeritageSet.Find(id);
            if (heritage == null)
            {
                return HttpNotFound();
            }
            return View(heritage);
        }

        // GET: Heritages/Create
        public ActionResult Create()
        {
            if (HomeController.Type.Equals("user"))
            {
                return Content("You are not allowed to do this！");
            }
                return View();
        }

        // POST: Heritages/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,hname,address,pic")] Heritage heritage)
        {
            if (HomeController.Type.Equals("user"))
            {
                return Content("You are not allowed to do this！");
            }
            if (ModelState.IsValid)
            {
                db.HeritageSet.Add(heritage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heritage);
        }

        // GET: Heritages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (HomeController.Type.Equals("user"))
            {
                return Content("You are not allowed to do this！");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritage heritage = db.HeritageSet.Find(id);
            if (heritage == null)
            {
                return HttpNotFound();
            }
            return View(heritage);
        }

        // POST: Heritages/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,hname,address,pic")] Heritage heritage)
        {
            if (HomeController.Type.Equals("user"))
            {
                return Content("You are not allowed to do this！");
            }
            if (ModelState.IsValid)
            {
                db.Entry(heritage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heritage);
        }

        // GET: Heritages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HomeController.Type.Equals("user"))
            {
                return Content("You are not allowed to do this！");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritage heritage = db.HeritageSet.Find(id);
            if (heritage == null)
            {
                return HttpNotFound();
            }
            return View(heritage);
        }

        // POST: Heritages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HomeController.Type.Equals("user"))
            {
                return Content("You are not allowed to do this！");
            }
            Heritage heritage = db.HeritageSet.Find(id);
            db.HeritageSet.Remove(heritage);
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

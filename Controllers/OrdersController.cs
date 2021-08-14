﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_MyJs.Models;

namespace FIT5032_MyJs.Controllers
{
    public class OrdersController : Controller
    {
        private UserContainer db = new UserContainer();

        // GET: Orders
        public ActionResult Index()
        {
            var orderSet = db.OrderSet.Include(o => o.User).Include(o => o.Heritage).Include(o => o.Admin);
            if (HomeController.Type.Equals("user"))
            {
                var user = db.UserSet.Where(u => u.name == HomeController.UserName).SingleOrDefault();
                var user_id = user.Id;
                orderSet = db.OrderSet.Include(o => o.User).Include(o => o.Heritage).Include(o => o.Admin).Where(u => u.user_id == user_id);
            }
            return View(orderSet.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.OrderSet.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Email");
            ViewBag.HeritageId = new SelectList(db.HeritageSet, "Id", "hname");
            ViewBag.AdminId = new SelectList(db.AdminSet, "Id", "password");
            return View();
        }

        // POST: Orders/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,user_id,heritage_id,create_time,detail,UserId,HeritageId,AdminId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.OrderSet.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Email", order.UserId);
            ViewBag.HeritageId = new SelectList(db.HeritageSet, "Id", "hname", order.HeritageId);
            ViewBag.AdminId = new SelectList(db.AdminSet, "Id", "password", order.AdminId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.OrderSet.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Email", order.UserId);
            ViewBag.HeritageId = new SelectList(db.HeritageSet, "Id", "hname", order.HeritageId);
            ViewBag.AdminId = new SelectList(db.AdminSet, "Id", "password", order.AdminId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,user_id,heritage_id,create_time,detail,UserId,HeritageId,AdminId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Email", order.UserId);
            ViewBag.HeritageId = new SelectList(db.HeritageSet, "Id", "hname", order.HeritageId);
            ViewBag.AdminId = new SelectList(db.AdminSet, "Id", "password", order.AdminId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.OrderSet.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.OrderSet.Find(id);
            db.OrderSet.Remove(order);
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

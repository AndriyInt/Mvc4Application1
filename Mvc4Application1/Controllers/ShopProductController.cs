using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4Application1.Models;

namespace Mvc4Application1.Controllers
{
    public class ShopProductController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        //
        // GET: /ShopProduct/

        public ActionResult Index()
        {
            return View(db.ShopProducts.ToList());
        }

        //
        // GET: /ShopProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            ShopProduct shopproduct = db.ShopProducts.Find(id);
            if (shopproduct == null)
            {
                return HttpNotFound();
            }
            return View(shopproduct);
        }

        //
        // GET: /ShopProduct/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ShopProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopProduct shopproduct)
        {
            if (ModelState.IsValid)
            {
                db.ShopProducts.Add(shopproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shopproduct);
        }

        //
        // GET: /ShopProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ShopProduct shopproduct = db.ShopProducts.Find(id);
            if (shopproduct == null)
            {
                return HttpNotFound();
            }
            return View(shopproduct);
        }

        //
        // POST: /ShopProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopProduct shopproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopproduct);
        }

        //
        // GET: /ShopProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ShopProduct shopproduct = db.ShopProducts.Find(id);
            if (shopproduct == null)
            {
                return HttpNotFound();
            }
            return View(shopproduct);
        }

        //
        // POST: /ShopProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShopProduct shopproduct = db.ShopProducts.Find(id);
            db.ShopProducts.Remove(shopproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
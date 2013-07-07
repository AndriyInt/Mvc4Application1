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
    public class ShopCategoryController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        //
        // GET: /ShopCategory/

        public ActionResult Index()
        {
            return View(db.ShopCategories.ToList());
        }

        //
        // GET: /ShopCategory/Details/5

        public ActionResult Details(int id = 0)
        {
            ShopCategory shopcategory = db.ShopCategories.Find(id);
            if (shopcategory == null)
            {
                return HttpNotFound();
            }
            return View(shopcategory);
        }

        //
        // GET: /ShopCategory/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ShopCategory/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopCategory shopcategory)
        {
            if (ModelState.IsValid)
            {
                db.ShopCategories.Add(shopcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shopcategory);
        }

        //
        // GET: /ShopCategory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ShopCategory shopcategory = db.ShopCategories.Find(id);
            if (shopcategory == null)
            {
                return HttpNotFound();
            }
            return View(shopcategory);
        }

        //
        // POST: /ShopCategory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopCategory shopcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopcategory);
        }

        //
        // GET: /ShopCategory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ShopCategory shopcategory = db.ShopCategories.Find(id);
            if (shopcategory == null)
            {
                return HttpNotFound();
            }
            return View(shopcategory);
        }

        //
        // POST: /ShopCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShopCategory shopcategory = db.ShopCategories.Find(id);
            db.ShopCategories.Remove(shopcategory);
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
namespace Mvc4Application1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Mvc4Application1.DAL;

    public class CategoriesController : Controller
    {
        private readonly Mvc4Application1DBEntities db = new Mvc4Application1DBEntities();

        // GET: /Categories/
        public ActionResult Index(int startFrom = 0, int categoriesPerPage = -1)
        {
            if (categoriesPerPage == -1)
            {
                categoriesPerPage = Consts.CategoriesPerPage;
            }

            int categoriesCount = this.db.Categories.Count();
            ViewBag.PageNo = startFrom / categoriesPerPage;
            ViewBag.PagesCount = categoriesCount / categoriesPerPage;
            ViewBag.CategoriesPerPage = categoriesPerPage;

            var categories = this.db.Categories
                ////.Include(c => c.Category1);
                .OrderBy(category => category.CategoryId).Skip(startFrom).Take(categoriesPerPage);
            return this.View(categories.ToList());
        }

        // GET: /Categories/Details/5
        public ActionResult Details(int id = 0)
        {
            Category category = this.db.Categories.Find(id);
            if (category == null)
            {
                return this.HttpNotFound();
            }

            return this.View(category);
        }

        // GET: /Categories/Create
        public ActionResult Create()
        {
            ViewBag.ParentCategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: /Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Name == null)
                {
                    category.Name = string.Empty;
                }

                if (category.Description == null)
                {
                    category.Description = string.Empty;
                }

                this.db.Categories.Add(category);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            ViewBag.ParentCategoryId = new SelectList(this.db.Categories, "CategoryId", "Name", category.ParentCategoryId);
            return this.View(category);
        }

        // GET: /Categories/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Category category = this.db.Categories.Find(id);
            if (category == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.ParentCategoryId = new SelectList(this.db.Categories, "CategoryId", "Name", category.ParentCategoryId);
            return this.View(category);
        }

        // POST: /Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Name == null)
                {
                    category.Name = string.Empty;
                }

                if (category.Description == null)
                {
                    category.Description = string.Empty;
                }

                this.db.Entry(category).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            ViewBag.ParentCategoryId = new SelectList(this.db.Categories, "CategoryId", "Name", category.ParentCategoryId);
            return this.View(category);
        }

        // GET: /Categories/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Category category = this.db.Categories.Find(id);
            if (category == null)
            {
                return this.HttpNotFound();
            }

            return this.View(category);
        }

        // POST: /Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = this.db.Categories.Find(id);
            this.db.Categories.Remove(category);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
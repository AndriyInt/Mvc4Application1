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

    public class ProductsController : Controller
    {
        private readonly Mvc4Application1DBEntities db = new Mvc4Application1DBEntities();

        // GET: /Products/
        public ActionResult Index()
        {
            return this.View(this.db.Products.ToList());
        }

        // GET: /Products/Details/5
        public ActionResult Details(int id = 0)
        {
            Product product = this.db.Products.Find(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }
            return this.View(product);
        }

        // GET: /Products/Create
        public ActionResult Create()
        {
            ViewBag.categoriesSelectTemplate = new SelectList(this.db.Categories, "CategoryId", "Name");
            return this.View();
        }

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc, Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Name == null)
                {
                    product.Name = string.Empty;
                }

                if (product.Description == null)
                {
                    product.Description = string.Empty;
                }

                foreach (string field in fc)
                {
                    if (field.StartsWith("category"))
                    {
                        var catId = int.Parse(fc[field]);
                        var cat = this.db.Categories.Find(catId);
                        product.Categories.Add(cat);
                    }
                }

                this.db.Products.Add(product);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            ViewBag.categoriesSelectTemplate = new SelectList(this.db.Categories, "CategoryId", "Name");
            return this.View(product);
        }

        // GET: /Products/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var product = this.db.Products.Find(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.categoriesSelectTemplate = new SelectList(this.db.Categories, "CategoryId", "Name");
            ViewBag.CategoriesIds = string.Join(",", product.Categories.Select(c => c.CategoryId));
            return this.View(product);
        }

        // POST: /Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection fc, Product product)
        {
            ////try
            ////{
                if (ModelState.IsValid)
                {
                    // Copy values
                    var realProduct = this.db.Products.Find(product.ProductId);

                    realProduct.Name = product.Name ?? string.Empty;
                    realProduct.Description = product.Description ?? string.Empty;
                    realProduct.ImageUrl = product.ImageUrl;
                    realProduct.Price = product.Price;
                    realProduct.IsFeatured = product.IsFeatured;
                    realProduct.IsPublished = product.IsPublished;

                    // Categories
                    realProduct.Categories.Clear();
                    foreach (string field in fc)
                    {
                        if (field.StartsWith("category"))
                        {
                            var catId = int.Parse(fc[field]);
                            var cat = this.db.Categories.Find(catId);
                            realProduct.Categories.Add(cat);
                        }
                    }

                    this.db.SaveChanges();
                    return this.RedirectToAction("Index");
                }
            ////}
            ////catch (Exception ex)
            ////{
            ////    ViewBag.Error = ex;
            ////    throw;
            ////}

            ViewBag.categoriesSelectTemplate = new SelectList(this.db.Categories, "CategoryId", "Name");
            ViewBag.CategoriesIds = string.Join(",", product.Categories.Select(c => c.CategoryId));
            return this.View(product);
        }

        // GET: /Products/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var product = this.db.Products.Find(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            return this.View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = this.db.Products.Find(id);
            this.db.Products.Remove(product);
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
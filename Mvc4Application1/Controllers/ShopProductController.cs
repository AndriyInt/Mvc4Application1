namespace Andriy.Mvc4Application1.Controllers
{
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;

    using Andriy.Mvc4Application1.Models;

    public class ShopProductController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        //
        // GET: /ShopProduct/

        public ActionResult Index()
        {
            return this.View(this.db.ShopProducts.ToList());
        }

        //
        // GET: /ShopProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            ShopProduct shopproduct = this.db.ShopProducts.Find(id);
            if (shopproduct == null)
            {
                return this.HttpNotFound();
            }
            return this.View(shopproduct);
        }

        //
        // GET: /ShopProduct/Create

        public ActionResult Create()
        {
            this.ViewBag.categoriesSelectTemplate = new SelectList(this.db.ShopCategories, "CategoryId", "Name");
            return this.View();
        }

        //
        // POST: /ShopProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc, ShopProduct shopproduct)
        {
            if (this.ModelState.IsValid)
            {
                shopproduct.Categories = new Collection<ShopCategory>();
                foreach (string field in fc)
                {
                    if (field.StartsWith("category"))
                    {
                        var catId = int.Parse(fc[field]);
                        var cat = this.db.ShopCategories.Find(catId);
                        shopproduct.Categories.Add(cat);
                    }
                }

                this.db.ShopProducts.Add(shopproduct);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            this.ViewBag.categoriesSelectTemplate = new SelectList(this.db.ShopCategories, "CategoryId", "Name");
            return this.View(shopproduct);
        }

        //
        // GET: /ShopProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ShopProduct shopproduct = this.db.ShopProducts.Find(id);
            if (shopproduct == null)
            {
                return this.HttpNotFound();
            }

            this.ViewBag.categoriesSelectTemplate = new SelectList(this.db.ShopCategories, "CategoryId", "Name");
            this.ViewBag.CategoriesIds = string.Join(",", shopproduct.Categories.Select(c => c.CategoryId));
            return this.View(shopproduct);
        }

        //
        // POST: /ShopProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection fc, ShopProduct shopproduct)
        {
            if (this.ModelState.IsValid)
            {
                shopproduct.Categories = new Collection<ShopCategory>();
                foreach (string field in fc)
                {
                    if (field.StartsWith("category"))
                    {
                        var catId = int.Parse(fc[field]);
                        var cat = this.db.ShopCategories.Find(catId);
                        shopproduct.Categories.Add(cat);
                    }
                }

                var realProduct = this.db.ShopProducts.Find(shopproduct.ProductId);
                realProduct.Name = shopproduct.Name;
                realProduct.Description = shopproduct.Description;
                realProduct.ImageUrl = shopproduct.ImageUrl;
                realProduct.IsFeatured = shopproduct.IsFeatured;
                realProduct.IsPublished = shopproduct.IsPublished;
                realProduct.Price = shopproduct.Price;
                realProduct.Categories.Clear();
                realProduct.Categories = shopproduct.Categories;

                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(shopproduct);
        }

        //
        // GET: /ShopProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ShopProduct shopproduct = this.db.ShopProducts.Find(id);
            if (shopproduct == null)
            {
                return this.HttpNotFound();
            }
            return this.View(shopproduct);
        }

        //
        // POST: /ShopProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShopProduct shopproduct = this.db.ShopProducts.Find(id);
            this.db.ShopProducts.Remove(shopproduct);
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
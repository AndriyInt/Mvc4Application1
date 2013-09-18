namespace Andriy.Mvc4Application1.Controllers
{
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;

    using Andriy.Mvc4Application1.Models;

    public class ShopCategoryController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        //
        // GET: /ShopCategory/

        public ActionResult Index()
        {
            return this.View(this.db.ShopCategories.ToList());
        }

        //
        // GET: /ShopCategory/Details/5

        public ActionResult Details(int id = 0)
        {
            ShopCategory shopcategory = this.db.ShopCategories.Find(id);
            if (shopcategory == null)
            {
                return this.HttpNotFound();
            }
            return this.View(shopcategory);
        }

        //
        // GET: /ShopCategory/Create

        public ActionResult Create()
        {
            return this.View();
        }

        //
        // POST: /ShopCategory/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopCategory shopcategory)
        {
            if (this.ModelState.IsValid)
            {
                this.db.ShopCategories.Add(shopcategory);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(shopcategory);
        }

        //
        // GET: /ShopCategory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ShopCategory shopcategory = this.db.ShopCategories.Find(id);
            if (shopcategory == null)
            {
                return this.HttpNotFound();
            }
            this.ViewBag.CategorySelectList = this.GetCategorySelectList(shopcategory);
            return this.View(shopcategory);
        }

        //
        // POST: /ShopCategory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection fc, ShopCategory shopcategory)
        {
            if (this.ModelState.IsValid)
            {
                var origShopCategory = this.db.ShopCategories.Single(c => c.CategoryId == shopcategory.CategoryId);

                origShopCategory.Name = shopcategory.Name;
                origShopCategory.Description = shopcategory.Description;

                int parentCategoryId;
                origShopCategory.ParentCategory = int.TryParse(fc["NewParentCategoryId"], out parentCategoryId)
                                                  ? this.db.ShopCategories.Find(parentCategoryId)
                                                  : null;

                ////this.db.Entry(shopcategory).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
                ////this.ViewBag.CategorySelectList = this.GetCategorySelectList(origShopCategory);
                ////return this.View(origShopCategory);
            }

            this.ViewBag.CategorySelectList = this.GetCategorySelectList(shopcategory);
            return this.View(shopcategory);
        }

        //
        // GET: /ShopCategory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ShopCategory shopcategory = this.db.ShopCategories.Find(id);
            if (shopcategory == null)
            {
                return this.HttpNotFound();
            }
            return this.View(shopcategory);
        }

        //
        // POST: /ShopCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShopCategory shopcategory = this.db.ShopCategories.Find(id);
            this.db.ShopCategories.Remove(shopcategory);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        private SelectList GetCategorySelectList(ShopCategory category)
        {
            return new SelectList(this.db.ShopCategories, "CategoryId", "Name", category.GetParentCategoryId());
        }
    }
}
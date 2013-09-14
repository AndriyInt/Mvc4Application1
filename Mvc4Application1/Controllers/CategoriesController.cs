namespace Andriy.Mvc4Application1.Controllers
{
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;

    using Andriy.Mvc4Application1.DAL;

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
            this.ViewBag.PageNo = startFrom / categoriesPerPage;
            this.ViewBag.PagesCount = categoriesCount / categoriesPerPage;
            this.ViewBag.CategoriesPerPage = categoriesPerPage;

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
            this.ViewBag.ParentCategoryId = new SelectList(this.db.Categories, "CategoryId", "Name");
            return this.View();
        }

        // POST: /Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (this.ModelState.IsValid)
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

            this.ViewBag.ParentCategoryId = new SelectList(this.db.Categories, "CategoryId", "Name", category.ParentCategoryId);
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

            this.ViewBag.ParentCategoryId = new SelectList(this.db.Categories, "CategoryId", "Name", category.ParentCategoryId);
            return this.View(category);
        }

        // POST: /Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (this.ModelState.IsValid)
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

            this.ViewBag.ParentCategoryId = new SelectList(this.db.Categories, "CategoryId", "Name", category.ParentCategoryId);
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
namespace Andriy.Mvc4Application1.Controllers
{
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
            return this.View();
        }

        //
        // POST: /ShopProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopProduct shopproduct)
        {
            if (this.ModelState.IsValid)
            {
                this.db.ShopProducts.Add(shopproduct);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

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
            return this.View(shopproduct);
        }

        //
        // POST: /ShopProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopProduct shopproduct)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(shopproduct).State = EntityState.Modified;
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
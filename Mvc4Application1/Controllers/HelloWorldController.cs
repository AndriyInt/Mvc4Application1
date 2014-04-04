namespace Andriy.Mvc4Application1.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Andriy.Mvc4Application1.Models;

    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            this.ViewBag.Message = LResources.HelloWorld.Index.Welcome;

            return this.View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            this.ViewBag.Message = "Hello " + name;
            this.ViewBag.NumTimes = numTimes;

            return this.View();
        }

        ////[HttpPost]
        ////public ActionResult Other(string submit)
        ////{
        ////    ViewBag.flag = submit;
        ////    return this.View();
        ////}

        public ActionResult Other(string submit)
        {
            this.ViewBag.flag = submit;
            return this.View();
        }

        public ActionResult Other2()
        {
            var movie = new Models.Movie { Title = "CustomTitle" };

            var db = new Models.MovieDBContext();
            var cats = db.ShopCategories.ToArray();
            return this.View(movie);
        }

        public ActionResult Exception()
        {
            throw new Exception("Exception action");
        }

        public ActionResult ShowPerson()
        {
            return this.View(new DAL.Person { BirthDate = DateTime.Parse("1/2/1967"), MonthlyExpenses = 3000m });
        }

        [HttpPost]
        public ActionResult ShowPerson(FormCollection fc, DAL.Person person)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(person);
        }

        public string Books(int id = -1)
        {
            return "Book #" + id;
        }

        public string Books2(int id)
        {
            return "Book v2 #" + id;
        }

        public ActionResult ShowCategories(int startFrom = 0, int categoriesPerPageParam = 10)
        {
            using (var db = new DAL.Mvc4Application1DBEntities())
            {
                int categoriesPerPage = categoriesPerPageParam;
                
                var categories = db.Categories.OrderBy(category => category.CategoryId).Skip(startFrom).Take(categoriesPerPage).ToList();

                int categoriesCount = db.Categories.Count();
                ////ViewBag.CategoriesCount = categoriesCount;
                this.ViewBag.PageNo = startFrom / categoriesPerPage;
                this.ViewBag.PagesCount = categoriesCount / categoriesPerPage;
                this.ViewBag.CategoriesPerPage = categoriesPerPage;


                return this.View(categories);
            }
        }

        public string ShopCategoryTest()
        {
            using (var db = new MovieDBContext())
            {
                var generalCategory = db.ShopCategories.Single(c => c.CategoryId == 1);
                var computerPeriphCategory = db.ShopCategories.Single(c => c.CategoryId == 3);
                var miceCategory = db.ShopCategories.Where(c => c.CategoryId == 4).Single();
                
                if (miceCategory.ParentCategory != null)
                {
                    miceCategory.ParentCategory = miceCategory.ParentCategory.CategoryId == 3
                                                      ? generalCategory
                                                      : computerPeriphCategory;
                }

                db.SaveChanges();

                return "ShopCategoryTest complete";
            }
        }

        public ActionResult UploadTest()
        {
            return this.View();
        }
    }
}

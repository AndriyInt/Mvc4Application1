namespace Mvc4Application1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            ViewBag.Message = LResources.HelloWorld.Index.Welcome;

            return this.View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

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
            ViewBag.flag = submit;
            return this.View();
        }

        public ActionResult Other2()
        {
            var movie = new Models.Movie { Title = "CustomTitle" };
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
            if (ModelState.IsValid)
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
                ViewBag.PageNo = startFrom / categoriesPerPage;
                ViewBag.PagesCount = categoriesCount / categoriesPerPage;
                ViewBag.CategoriesPerPage = categoriesPerPage;


                return this.View(categories);
            }
        }
    }
}

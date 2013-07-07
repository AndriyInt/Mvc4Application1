namespace Mvc4Application1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ////ViewBag.Message = "Welcome!";
            ////ViewBag.Message = Resources.WebAppRes.WelcomeText; // Causes error on test
            ViewBag.Message = LResources.HelloWorld.Index.Welcome;

            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            ViewBag.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            ViewBag.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture;

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }

        public ActionResult FromDevs()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return this.View();
        }

        public ActionResult Other()
        {
            ViewBag.Message = "Other stuff";

            return this.View();
        }
    }
}

namespace Andriy.Mvc4Application1.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ////ViewBag.Message = "Welcome!";
            ////ViewBag.Message = Resources.WebAppRes.WelcomeText; // Causes error on test
            this.ViewBag.Message = LResources.HelloWorld.Index.Welcome;

            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your app description page.";
            this.ViewBag.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            this.ViewBag.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture;

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        public ActionResult FromDevs()
        {
            this.ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return this.View();
        }

        public ActionResult Other()
        {
            this.ViewBag.Message = "Other stuff";

            return this.View();
        }
    }
}

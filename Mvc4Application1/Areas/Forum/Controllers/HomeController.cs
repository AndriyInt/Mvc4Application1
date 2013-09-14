namespace Andriy.Mvc4Application1.Areas.Forum.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        //
        // GET: /Forum/Home/

        public ActionResult Index()
        {
            return this.View();
        }

    }
}

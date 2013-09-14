namespace Andriy.Mvc4Application1.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        // GET: /Error/
        public ActionResult Index()
        {
            return this.View();
        }

        // 403
        public ActionResult Forbidden()
        {
            this.Response.StatusCode = 403;
            return this.View();
        }

        // 404
        public ActionResult NotFound()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }

        // 500
        public ActionResult InternalServer()
        {
            this.Response.StatusCode = 500;
            return this.View();
        }

    }
}

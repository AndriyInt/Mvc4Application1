using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4Application1.Areas.Forum.Controllers
{
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

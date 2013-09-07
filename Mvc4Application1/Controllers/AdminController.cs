using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4Application1.Controllers
{
    using System.Globalization;
    using System.Reflection;

    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            var informationalVersionAttribute =
                (AssemblyInformationalVersionAttribute)
                Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute));
            this.ViewBag.Version = informationalVersionAttribute.InformationalVersion;
            return this.View();
        }

    }
}

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

        [Authorize(Roles = "Admin, Super User")]
        public ActionResult Index()
        {
            var informationalVersionAttribute =
                (AssemblyInformationalVersionAttribute)
                Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute));
            this.ViewBag.Version = informationalVersionAttribute.InformationalVersion;
            return this.View();
        }

        [Authorize(Roles = "Admin, Super User")]
        public void DownloadLog()
        {
            this.Response.WriteFile(Server.MapPath("~/Logs/2013.09.07.log.resources"));
        }
    }
}

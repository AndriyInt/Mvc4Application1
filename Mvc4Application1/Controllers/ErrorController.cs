﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4Application1.Controllers
{
    public class ErrorController : Controller
    {
        // GET: /Error/
        public ActionResult Index()
        {
            return View();
        }

        // 403
        public ActionResult Forbidden()
        {
            this.Response.StatusCode = 403;
            return View();
        }

        // 404
        public ActionResult NotFound()
        {
            this.Response.StatusCode = 404;
            return View();
        }

        // 500
        public ActionResult InternalServer()
        {
            this.Response.StatusCode = 500;
            return View();
        }

    }
}

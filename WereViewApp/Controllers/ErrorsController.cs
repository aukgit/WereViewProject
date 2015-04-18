﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WereViewApp.Controllers {
    [OutputCache(CacheProfile = "YearNoParam")]
    public class ErrorsController : Controller {
        // GET: Errors
        public ActionResult Index() {
            return View("_Error");
        }
        public ActionResult Error_403() {
            return View("_403");
        }
        public ActionResult Error_404() {
            return View("_404");
        }
        public ActionResult Error_415() {
            return View("_415");
        }
        public ActionResult Error_451() {
            return View("_451");
        }
        public ActionResult Error_500() {
            return View("_500");
        }
        public ActionResult Error_502() {
            return View("_502");
        }
    }
}
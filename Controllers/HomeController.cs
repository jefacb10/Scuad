using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scuad.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Charge()
        {
            return View("~/Views/Charge/ChargeView.cshtml");
        }
        public ActionResult Users()
        {
            return View("~/Views/Users/UsersView.cshtml");
        }
    }
}
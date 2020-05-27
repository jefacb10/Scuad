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
            return View("~/Views/Home/HomeView.cshtml");
        }


        public ActionResult Change(string tela)
        {
            switch (tela)
            {
                case "Cargos":
                    return RedirectToRoute(new { controller = "Charge", action = "Index" });
                case "Usuários":
                    return RedirectToRoute(new { controller = "Users", action = "Index" });
                default:
                    return View();
            }
        }

    }
}
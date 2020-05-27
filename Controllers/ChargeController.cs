using System.Web.Mvc;

namespace Scuad.Controllers
{
    public class ChargeController : Controller
    {

        // GET: Charge
        public ActionResult Index()
        {
            return View("~/Views/Charge/ChargeView.cshtml");
        }

        [HttpGet]
        public ActionResult ListarCargos()
        {
            return View();
        }

        public ActionResult Home()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public ActionResult Users()
        {
            return RedirectToRoute(new { controller = "Users", action = "Index" });
        }
    }
}
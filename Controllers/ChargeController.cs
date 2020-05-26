using System.Web.Mvc;

namespace Scuad.Controllers
{
    public class ChargeController : Controller
    {

        // GET: Charge
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarCargos()
        {
            return View();
        }

    }
}
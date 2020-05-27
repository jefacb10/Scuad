using Scuad.Repository.Cargos;
using Scuad.ViewModel;
using System.Web.Mvc;

namespace Scuad.Controllers
{
    public class ChargeController : Controller
    {
        private readonly IChargeRepository _chargeRepository;

        public ChargeController()
        {
            _chargeRepository = new ChargeSqlRepository();
        }

        // GET: Charge
        public ActionResult Index()
        {
            var cvm = new ChargeViewModel();
            cvm.ChargesList = _chargeRepository.ListarCargos();
            return View("~/Views/Charge/ChargeView.cshtml", cvm);
        }

        [HttpPost]
        public ActionResult SaveCharge(ChargeViewModel cvm)
        {
            if (cvm.Charge.Name != null) {
                 _chargeRepository.SalvarCargo(
                    cvm.Charge.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Home()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public ActionResult Users()
        {
            return RedirectToRoute(new { controller = "Users", action = "Index" });
        }
        [HttpPost]
        public ActionResult UpdateActive(
            int idCharge = 0)
        {
            var idRecebido = idCharge;
            if (idRecebido == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _chargeRepository.AlterarAtivo(idRecebido);
                return RedirectToAction("Index");
            }
        }
    }
}
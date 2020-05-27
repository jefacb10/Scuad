using Scuad.Repository.Cargos;
using Scuad.Repository.Usuarios;
using Scuad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scuad.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _userRepository;
        private readonly IChargeRepository _chargeRepository;

        public UsersController()
        {
            _userRepository = new UsersSqlRepository();
            _chargeRepository = new ChargeSqlRepository();
        }


        // GET: Users
        public ActionResult Index()
        {
            UsersViewModel uvm = new UsersViewModel();

            uvm.Charges = _userRepository.ListarCargos();
            uvm.UsersList = _userRepository.ListarUsuarios();
            return View("~/Views/Users/UsersView.cshtml", uvm);
        }

        public ActionResult Home()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public ActionResult Charge()
        {
            return RedirectToRoute(new { controller = "Charge", action = "Index" });
            
        }

        [HttpPost]
        public ActionResult SaveUser(UsersViewModel uvm)
        {
            if (uvm.Users.UserName != null 
                && uvm.Users.Charges.Name != null)
            {
                uvm.Users.Charges.IdCharge = _chargeRepository.ListarIdCargo(uvm.Users.Charges.Name); 
                _userRepository.SalvarUsuario(
                    uvm.Users.UserName,
                    uvm.Users.Charges.IdCharge);
            }
            return RedirectToAction("Index");
        }
    }
}
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

        public UsersController()
        {
            _userRepository = new UsersSqlRepository();
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
    }
}
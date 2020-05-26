using Scuad.Models;
using Scuad.Repository;
using System.Web.Mvc;

namespace Scuad.Controllers
{
    public sealed class LoginUserController : Controller
    {
        private readonly LoginSqlRepository _loginRepository;

        public LoginUserController()
        {
            _loginRepository = new LoginSqlRepository();
        }

        public ActionResult Index()
        {
            Users users = new Users();
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users users)
        {
            var result = _loginRepository.consultarLogin(
                users.UserName,
                users.Password);

            if(result > 0)
            {
                Session["username"] = users.UserName;
                return View("~/Views/Home/HomeView.cshtml");
            }
            else
            {
                ViewBag.Error = "Usuário e/ou senha incorretos";
                return View("Index");
            }
            
        }
    }
}
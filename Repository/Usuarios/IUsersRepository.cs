using Scuad.Models;
using Scuad.Models.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scuad.Repository.Usuarios
{
    public interface IUsersRepository
    {
        List<Charge> ListarCargos();
        List<Users> ListarUsuarios();
        void SalvarUsuario(
            string nome,
            int cargo);
    }
}
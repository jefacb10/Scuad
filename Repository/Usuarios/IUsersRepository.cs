using Scuad.Models;
using Scuad.Models.Cargos;
using System.Collections.Generic;

namespace Scuad.Repository.Usuarios
{
    public interface IUsersRepository
    {
        List<Charge> ListarCargos();

        List<Users> ListarUsuarios();

        void SalvarUsuario(
            string nome,
            int cargo);

        void AlterarAtivo(
            int idUser);
    }
}
using Scuad.Models.Cargos;
using System.Collections.Generic;

namespace Scuad.Repository.Cargos
{
    public interface IChargeRepository
    {
        List<Charge> ListarCargos();

        void AlterarAtivo(
            int idCargo);

        int ListarIdCargo(
            string nomeCargo);
        void SalvarCargo(
            string nomeCargo);

    }
}
using Scuad.Models.Cargos;
using System.Collections.Generic;

namespace Scuad.Repository.Cargos
{
    public interface IChargeRepository
    {
        List<Charge> ListarCargos();

        bool AtualizarAtivacao(
            int idCargo);

        int SalvarCargo(
            string nomeCargo,
            int ativo);

    }
}
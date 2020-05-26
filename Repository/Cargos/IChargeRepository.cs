using Scuad.Models.Cargos;
using System.Collections.Generic;

namespace Scuad.Repository.Cargos
{
    public interface IChargeRepository
    {
        IEnumerable<Charge> ConsultarCargos();

        int SelecionarCargo(
            string nomeCargo);

        bool AtualizarAtivacao(
            int idCargo);

        int SalvarCargo(
            string nomeCargo,
            int ativo);

    }
}
using Scuad.Models.Cargos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Scuad.Repository.Cargos
{
    public class ChargeSqlRepository :
        SqlRepository, IChargeRepository
    {
        public void AlterarAtivo(
            int idCargo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sql = $@"DECLARE    @Ativo INT = (SELECT ATIVO FROM CARGOS WHERE ID_CARGO={idCargo});
                            UPDATE	    CARGOS
                            SET		    ATIVO= CASE @Ativo WHEN 1 THEN 0 ELSE 1 END
                            WHERE       ID_CARGO={idCargo}";
                var command = new SqlCommand(sql, connection);
                var result = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Charge> ListarCargos()
        {
            var cargos = new List<Charge>();
            using (var connection = new SqlConnection(ConnectionString))
            {

                var sql = $@"SELECT     CARGO,
                                        ID_CARGO,
                                        CASE ATIVO WHEN 1 THEN 'Sim' ELSE 'Não' END AS ATIVO
                            FROM        dbo.CARGOS WITH(NOLOCK)";

                var command = new SqlCommand(sql, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cargo = new Charge()
                        {
                            Name = Convert.ToString(reader["CARGO"]),
                            IdCharge = Convert.ToInt32(reader["ID_CARGO"]),
                            IsActive = Convert.ToString(reader["ATIVO"])
                        };
                        cargos.Add(cargo);
                    }
                }
                connection.Close();
            }
            return cargos;
        }

        public int ListarIdCargo(
            string nomeCargo)
        {
            var idCargo = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {

                var sql = $@"SELECT     ID_CARGO
                            FROM        dbo.CARGOS WITH(NOLOCK)
                            WHERE       CARGO='{nomeCargo}'";

                var command = new SqlCommand(sql, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idCargo = Convert.ToInt32(reader["ID_CARGO"]);
                    }
                }
                connection.Close();
            }
            return idCargo;
        }

        public void SalvarCargo(
            string nomeCargo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sql = $@"INSERT INTO    dbo.CARGOS
                            (
	                            CARGO,
	                            ATIVO
                            )
                            VALUES
                            (
	                            '{nomeCargo.ToUpper()}',
	                            1
                            )";
                var command = new SqlCommand(sql, connection);
                var result = command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
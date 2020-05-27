using Scuad.Models;
using Scuad.Models.Cargos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Scuad.Repository.Usuarios
{
    public sealed class UsersSqlRepository:
        SqlRepository, IUsersRepository
    {
        public List<Charge> ListarCargos()
        {
            var cargos = new List<Charge>();
            using (var connection = new SqlConnection(ConnectionString))
            {

                var sql = $@"SELECT     CARGO                                        
                            FROM        dbo.CARGOS WITH(NOLOCK)
                            WHERE       ATIVO=1";

                var command = new SqlCommand(sql, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cargo = new Charge()
                        {
                            Name = Convert.ToString(reader[0])
                        };
                        cargos.Add(cargo);
                    }
                }
                connection.Close();
            }
            return cargos;
        }

        public List<Users> ListarUsuarios()
        {
            var usuarios = new List<Users>();
            using (var connection = new SqlConnection(ConnectionString))
            {

                var sql = $@"SELECT		USUARIOS.NOME,
			                            CARGOS.CARGO,
			                            CASE USUARIOS.ATIVO WHEN 1 THEN 'true' ELSE 'false' END AS ATIVO
                            FROM		dbo.USUARIOS WITH(NOLOCK)
                            INNER JOIN	CARGOS ON USUARIOS.ID_CARGO=CARGOS.ID_CARGO";

                var command = new SqlCommand(sql, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Users()
                        {

                            UserName = Convert.ToString(reader["NOME"]),
                            Charges = new Charge() { Name = Convert.ToString(reader["CARGO"])},
                            IsActive = Convert.ToBoolean(reader["ATIVO"])
                        };
                        usuarios.Add(usuario);
                    }
                }
                connection.Close();
            }
            return usuarios;
        }

        public void SalvarUsuario(
            string nome, 
            int cargo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sql = $@"IF NOT EXISTS(SELECT 1 FROM USUARIOS WHERE NOME='{nome}')
	                                INSERT INTO USUARIOS(NOME,ID_CARGO, ATIVO)
	                                VALUES ('{nome}', '{cargo}', 1)
                             ELSE
	                                UPDATE USUARIOS
	                                SET ID_CARGO='{cargo}'
	                                WHERE NOME='{nome}'";
                var command = new SqlCommand(sql, connection);
                var result = command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
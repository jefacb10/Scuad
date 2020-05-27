using System;
using System.Data.SqlClient;

namespace Scuad.Repository
{
    public sealed class LoginSqlRepository : 
        SqlRepository, ILoginRepository
    {
        public int ConsultarLogin(
            string usuario, 
            string senha)
        {
            var result = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                
                var sql = $@"SELECT     COUNT(*)
                             FROM       dbo.USUARIOS WITH(NOLOCK)
                             WHERE      NOME='{usuario}' 
                                        AND SENHA='{senha}'";

                var command = new SqlCommand(sql, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = Convert.ToInt32(reader[0]);
                    }
                }
                connection.Close();
            }
            return result;
        }
    }
}
using System.Configuration;

namespace Scuad.Repository
{
    public abstract class SqlRepository
    {
        public string ConnectionString { get; set; }

        public SqlRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

    }
}
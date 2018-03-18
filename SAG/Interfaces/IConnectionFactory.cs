using System.Data.SqlClient;

namespace SAG.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}

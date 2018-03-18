using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SAG.Interfaces;

namespace SAG.Helpers
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;
        public ConnectionFactory(string connection)
        {
            connectionString = connection;
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

    }
}
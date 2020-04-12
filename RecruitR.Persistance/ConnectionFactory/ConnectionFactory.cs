using System;
using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace RecruitR.Persistence.ConnectionFactory
{
    public class ConnectionFactory : IConnectionFactory, IDisposable
    {
        private readonly string _connectionString;
        public IDbConnection connection;

        public ConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("RecruitConnection");
        }

        public IDbConnection GetOpenConnection()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                connection = new NpgsqlConnection(_connectionString);
            }

            return connection;
        }


        public void Dispose()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Dispose();
            }
        }
    }
}
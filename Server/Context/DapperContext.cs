using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Types;

namespace CareMod.Server.Context
{
    public class DapperContext

    {

        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)

        {

            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CONEXIONORACLE");

        }

        public IDbConnection CreateConnection()    
        => new OracleConnection(_connectionString);

    }

}

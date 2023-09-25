using pj3_api.Model;
using System.Data;
using System.Data.SqlClient;

namespace pj3_api.Database
{
    public class MSSQLBaseDataSource
    {

        private readonly MSSQLSettings _mssqlSettings;

        public MSSQLBaseDataSource(MSSQLSettings mssqlSettings)
        {
            _mssqlSettings = mssqlSettings;
        }

        public IDbConnection CreateConnection()
        {
            var conn = new SqlConnection(_mssqlSettings.SQLConnectionString);
            return conn;
        }

    }
}

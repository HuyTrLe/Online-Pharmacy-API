using pj3_api.Database;
using pj3_api.Model;
using System.Data;

namespace pj3_api.Repository.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public AdminRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }
       
    }
}

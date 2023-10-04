using pj3_api.Database;
using pj3_api.Model;
using pj3_api.Model.User;
using System.Data;

namespace pj3_api.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public UserRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }
        public async Task<UserModel> Login(Login user)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@Email", user.Email, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Password", user.Password, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.First<UserModel>(UserQuery.GetUserByEmailPassword, parameters);
            return result;
        }

        public async Task<IEnumerable<UserModel>> GetUser()
        {        
            var result = await _sqlQueryDataSource.Value.Select<UserModel>(UserQuery.GetUser, null);
            return result;
        }

        public async Task<int> InsertUser(UserModel user)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserName", user.UserName, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Email", user.Email, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@PhoneNumber", user.PhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Address", user.Address, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Password", user.Password, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@RoleID", user.RoleID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Education", user.Education, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ID", user.ID, SqlDbType.Int, ParameterDirection.Output);
            var result = await _sqlQueryDataSource.Value.Insert(UserQuery.InsertUser, parameters);
            int newID = parameters.Get<int>("@ID");
            return newID;
        }

        public async Task<int> UpdateUser(UserModel user)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserName", user.UserName, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Email", user.Email, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@PhoneNumber", user.PhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Address", user.Address, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Password", user.Password, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@RoleID", user.RoleID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Education", user.Education, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ID", user.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Insert(UserQuery.UpdateUserByID, parameters);
            return result;
        }
     
    }
}

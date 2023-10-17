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

        public async Task<UserModelResult> GetUser(int ID)
        {
            UserModelResult userModelResult = new UserModelResult();
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", ID, SqlDbType.Int, ParameterDirection.Input);
            userModelResult.UserModel = await _sqlQueryDataSource.Value.First<UserModel>(UserQuery.GetUser, parameters);
            userModelResult.Education = await GetEducation(ID);
            return userModelResult;
        }
        public async Task<List<Education>> GetEducation(int UserID)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserID", UserID, SqlDbType.Int, ParameterDirection.Input);
            var result = await  _sqlQueryDataSource.Value.Select<Education>(UserQuery.GetEducation, parameters);
            return result.ToList();
        }


        public async Task<int> InsertUser(UserModel user)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserName", user.UserName, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Email", user.Email, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@PhoneNumber", user.PhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Address", user.Address, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Password", user.Password, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@RoleID", 2/*User*/, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@ID", user.ID, SqlDbType.Int, ParameterDirection.Output);
            var result = await _sqlQueryDataSource.Value.Insert(UserQuery.InsertUser, parameters);
            int newID = parameters.Get<int>("@ID");
            return newID;
        }

        public async Task<int> UpdateUser(UserModelResult user)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserName", user.UserModel.UserName, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Email", user.UserModel.Email, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@PhoneNumber", user.UserModel.PhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Address", user.UserModel.Address, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Password", user.UserModel.Password, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ID", user.UserModel.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Insert(UserQuery.UpdateUserByID, parameters);
            await UpdateUserEducation(user);
            return result;
        }


        public async Task<int> UpdateUserEducation(UserModelResult user)
        {
            try
            {
                int result = 0;
                foreach (var item in user.Education)
                {
                    if (item.ID != 0)
                    {
                        MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
                        parameters.Add("@SchoolName", item.SchoolName, SqlDbType.NVarChar, ParameterDirection.Input);
                        parameters.Add("@SchoolType", item.SchoolType, SqlDbType.NVarChar, ParameterDirection.Input);
                        parameters.Add("@Degree", item.Degree, SqlDbType.NVarChar, ParameterDirection.Input);
                        parameters.Add("@From", item.From, SqlDbType.DateTime, ParameterDirection.Input);
                        parameters.Add("@To", item.To, SqlDbType.DateTime, ParameterDirection.Input);
                        parameters.Add("@ID", item.ID, SqlDbType.Int, ParameterDirection.Input);
                        result = await _sqlQueryDataSource.Value.Update(UserQuery.UpdateEducation, parameters);
                    }
                    else
                    {
                        MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
                        parameters.Add("@UserID", item.UserID, SqlDbType.NVarChar, ParameterDirection.Input);
                        parameters.Add("@SchoolName", item.SchoolName, SqlDbType.NVarChar, ParameterDirection.Input);
                        parameters.Add("@SchoolType", item.SchoolType, SqlDbType.NVarChar, ParameterDirection.Input);
                        parameters.Add("@Degree", item.Degree, SqlDbType.NVarChar, ParameterDirection.Input);
                        parameters.Add("@From", item.From, SqlDbType.DateTime, ParameterDirection.Input);
                        parameters.Add("@To", item.To, SqlDbType.DateTime, ParameterDirection.Input);
                        result = await _sqlQueryDataSource.Value.Update(UserQuery.InsertEducation, parameters);
                    }
                }

                return result;
            }
            catch(Exception ex) {
                return 0;
            }
            
        }

        public async Task<int> InsertRole(Role role)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@Name", role.Name, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Insert(UserQuery.InsertRole, parameters);
            return result;
            
        }

        public async Task<IEnumerable<Role>> GetRole()
        {
            var result = await _sqlQueryDataSource.Value.Select<Role>(UserQuery.GetRole, null);
            return result;
        }

        public async Task<int> UpdateRole(Role role)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@Name", role.Name, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ID", role.ID, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Insert(UserQuery.UpdateRole, parameters);
            return result;
        }

        public async Task<IEnumerable<Career>> GetCareer()
        {
            var result = await _sqlQueryDataSource.Value.Select<Career>(UserQuery.GetCareer, null) ;
            return result;
        }

        public async Task<int> InsertCareer(Career career)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserID", career.UserID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@File", career.File, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Status", career.Status, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Insert(UserQuery.InsertCareer, parameters);
            return result;
        }

        public async Task<int> UpdateCareer(Career career)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@Status", career.Status, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Update(UserQuery.UpdateCareer, parameters);
            return result;
        }

        public async Task<IEnumerable<Career>> GetCareerByUserID(Career career)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserID", career.UserID, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<Career>(UserQuery.GetCareerByUserID, parameters);
            return result;
        }
        public async Task<int> CheckPassword(ChangePassword ChangePassword)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserID", ChangePassword.UserID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Password", ChangePassword.Password, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<UserModel>(UserQuery.CheckPassword, parameters);
            if (result.Count() > 0)
                return 1;
            return 0;
        }
        public async Task<int> ChangePassword(ChangePassword ChangePassword)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserID", ChangePassword.UserID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Password", ChangePassword.Password, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Update(UserQuery.ChangePassword, parameters);
            return result;
        }
    }
}

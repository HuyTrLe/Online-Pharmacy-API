using pj3_api.Model;
using pj3_api.Model.User;

namespace pj3_api.Repository.User
{
    public interface IUserRepository
    {
        Task<UserModel> Login(Login user);

        Task<UserModelResult> GetUser(int ID);
        Task<IEnumerable<UserModelResult>> GetAllUser();
        Task<int> InsertUser(UserModel user);
        Task<int> UpdateUser(UserModelResult user);
        Task<int> UpdateRoleUser(UserModelUpdateRole user);
        Task<int> UpdateFilename(UploadFile user);
        Task<int> CheckPassword(ChangePassword ChangePassword);
        Task<int> ChangePassword(ChangePassword ChangePassword);
        Task<int> InsertRole(Role role);
        Task<IEnumerable<Role>> GetRole();
        Task<int> UpdateRole(Role role);
        Task<int> DeleteEducation(DeleteEducation deleteEducation);

    }
}

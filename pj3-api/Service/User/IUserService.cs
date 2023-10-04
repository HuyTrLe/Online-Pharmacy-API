using pj3_api.Model;
using pj3_api.Model.User;

namespace pj3_api.Service.User
{
    public interface IUserService
    {
        Task<UserModel> Login(Login user);

        Task<IEnumerable<UserModel>> GetUser();

        Task<int> InsertUser(UserModel user);
        Task<int> UpdateUser(UserModel user);
    }
}

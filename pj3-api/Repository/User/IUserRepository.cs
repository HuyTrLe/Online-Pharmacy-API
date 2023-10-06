using pj3_api.Model;
using pj3_api.Model.User;

namespace pj3_api.Repository.User
{
    public interface IUserRepository
    {
        Task<UserModel> Login(Login user);

        Task<IEnumerable<UserModel>> GetUser();

        Task<int> InsertUser(UserModel user);
        Task<int> UpdateUser(UserModel user);

        Task<int> InsertRole(Role role);
        Task<IEnumerable<Role>> GetRole();
        Task<int> UpdateRole(Role role);
        Task<IEnumerable<Career>> GetCareer();
        Task<int> InsertCareer(Career career);
        Task<int> UpdateCareer(Career career);
        Task<IEnumerable<Career>> GetCareerByUserID(Career career);

    }
}

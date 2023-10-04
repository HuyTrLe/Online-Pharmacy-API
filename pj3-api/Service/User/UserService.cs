using pj3_api.Model;
using pj3_api.Model.User;
using pj3_api.Repository.User;

namespace pj3_api.Service.User
{
    public class UserService : IUserService
    {
        private readonly Lazy<IUserRepository> _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = new Lazy<IUserRepository>(() => userRepository);
        }
        public async Task<UserModel> Login(Login user)
        {
            var result = await _userRepository.Value.Login(user);
            return result;
        }

        public async Task<IEnumerable<UserModel>> GetUser()
        {
            var result = await _userRepository.Value.GetUser();
            return result;
        }

        public async Task<int> InsertUser(UserModel user)
        {
            var result = await _userRepository.Value.InsertUser(user);
            return result;
        }

        public async Task<int> UpdateUser(UserModel user)
        {
            var result = await _userRepository.Value.UpdateUser(user);
            return result;
        }
    }
}

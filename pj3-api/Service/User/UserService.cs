using pj3_api.Model;
using pj3_api.Model.User;
using pj3_api.Repository.User;
using System.Data;

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

        public async Task<int> InsertRole(Role role)
        {
            var result = await _userRepository.Value.InsertRole(role);
            return result;
        }

        public async Task<IEnumerable<Role>> GetRole()
        {
            var result = await _userRepository.Value.GetRole();
            return result;
        }

        public async Task<int> UpdateRole(Role role)
        {
            var result = await _userRepository.Value.UpdateRole(role);
            return result;
        }

        public async Task<IEnumerable<Career>> GetCareer()
        {
            var result = await _userRepository.Value.GetCareer();
            return result;
        }

        public async Task<int> InsertCareer(Career career)
        {
            var result = await _userRepository.Value.InsertCareer(career);
            return result;
        }

        public async Task<int> UpdateCareer(Career career)
        {
            var result = await _userRepository.Value.UpdateCareer(career);
            return result;
        }

        public async Task<IEnumerable<Career>> GetCareerByUserID(Career career)
        {
            var result = await _userRepository.Value.GetCareerByUserID(career);
            return result;
        }
    }
}

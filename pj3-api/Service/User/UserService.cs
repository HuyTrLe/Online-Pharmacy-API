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

        public async Task<UserModelResult> GetUser(int ID)
        {
            var result = await _userRepository.Value.GetUser(ID);
            return result;
        }

        public async Task<int> InsertUser(UserModel user)
        {
            var result = await _userRepository.Value.InsertUser(user);
            return result;
        }

        public async Task<int> UpdateUser(UserModelResult user)
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

       
        public async Task<int> CheckPassword(ChangePassword ChangePassword)
        {
            var result = await _userRepository.Value.CheckPassword(ChangePassword);
            return result;
        }

        public async Task<int> ChangePassword(ChangePassword ChangePassword)
        {
            var result = await _userRepository.Value.ChangePassword(ChangePassword);
            return result;
        }

        public async Task<int> UpdateFilename(UploadFile user)
        {
            var result = await _userRepository.Value.UpdateFilename(user);
            return result;
        }

        public async Task<int> DeleteEducation(DeleteEducation deleteEducation)
        {
            var result = await _userRepository.Value.DeleteEducation(deleteEducation);
            return result;
        }

        public async Task<IEnumerable<UserModelResult>> GetAllUser()
        {
            var result = await _userRepository.Value.GetAllUser();
            return result;
        }

        public async Task<int> UpdateRoleUser(UserModelUpdateRole user)
        {
            var result = await _userRepository.Value.UpdateRoleUser(user);
            return result;
        }
    }
}

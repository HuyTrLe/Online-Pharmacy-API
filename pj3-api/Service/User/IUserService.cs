﻿using pj3_api.Model;
using pj3_api.Model.User;

namespace pj3_api.Service.User
{
    public interface IUserService
    {
        Task<UserModel> Login(Login user);

        Task<UserModelResult> GetUser(int ID);

        Task<int> InsertUser(UserModel user);
        Task<int> UpdateUser(UserModelResult user);
        Task<int> InsertRole(Role role);
        Task<IEnumerable<Role>> GetRole();
        Task<int> UpdateRole(Role role);
        Task<IEnumerable<Career>> GetCareer();
        Task<int> InsertCareer(Career career);
        Task<int> UpdateCareer(Career career);
        Task<IEnumerable<Career>> GetCareerByUserID(Career career);
    }
}

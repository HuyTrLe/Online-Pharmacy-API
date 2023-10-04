using Microsoft.AspNetCore.Mvc;
using pj3_api.Model;
using pj3_api.Model.User;
using pj3_api.Service.User;
using System.Net;

namespace pj3_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly Lazy<IUserService> _userService;
        public UserController(IUserService userService)
        {
            _userService = new Lazy<IUserService>(() => userService);
        }

        [HttpPost]
        public async Task<HttpResultObject> Login(Login login)
        {
            try
            {
                var result = await _userService.Value.Login(login);
                return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
            }
            catch(Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }
            
        }
        [HttpPost]
        public async Task<HttpResultObject> GetUser()
        {
            try
            {
                var result = await _userService.Value.GetUser();
                return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
        [HttpPost]
        public async Task<HttpResultObject> InsertUser(UserModel user)
        {
            try
            {
                var result = await _userService.Value.InsertUser(user);
                if(result != 0)
                    return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
                else
                    return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
        [HttpPost]
        public async Task<HttpResultObject> UpdateUser(UserModel user)
        {
            try
            {
                var result = await _userService.Value.UpdateUser(user);
                if (result != 0)
                    return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
                else
                    return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
    }
}

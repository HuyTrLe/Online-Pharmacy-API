using Microsoft.AspNetCore.Mvc;
using pj3_api.Model;
using pj3_api.Model.User;
using pj3_api.Service.Home;
using pj3_api.Service.Mail;
using pj3_api.Service.User;
using System.Net;
using System.Net.Mail;

namespace pj3_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IMailService> _mailService;
        public UserController(IUserService userService,IMailService mailService)
        {
            _userService = new Lazy<IUserService>(() => userService);
            _mailService = new Lazy<IMailService>(() => mailService);
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
        public async Task<HttpResultObject> GetUser(Login user)
        {
            try
            {
                var result = await _userService.Value.GetUser(user.ID);
                return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
        [HttpGet]
        public async Task<HttpResultObject> GetAllUser()
        {
            try
            {
                var result = await _userService.Value.GetAllUser();
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
        public async Task<HttpResultObject> UpdateUser(UserModelResult userModelResult)
        {
            try
            {
                var result = await _userService.Value.UpdateUser(userModelResult);
                if (result != 0)
                    return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
                else
                    return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = ex.Message };
            }

        }
        [HttpPost]
        public async Task<HttpResultObject> UpdateRole(Role role)
        {
            try
            {
                var result = await _userService.Value.UpdateRole(role);
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
        [HttpPost]
        public async Task<HttpResultObject> InsertRole(Role role)
        {
            try
            {
                var result = await _userService.Value.InsertRole(role);
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
        [HttpPost]
        public async Task<HttpResultObject> GetRole()
        {
            try
            {
                var result = await _userService.Value.GetRole();
                if (result != null)
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
        public async Task<HttpResultObject> InsertCareer(Career career)
        {
            try
            {
                var result = await _userService.Value.GetRole();
                if (result != null)
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
        public async Task<HttpResultObject> CheckPassword(ChangePassword changePassword)
        {
            try
            {
                var result = await _userService.Value.CheckPassword(changePassword);
                if (result != 0)
                    return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
                else
                    return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = 0, Message = "NotOK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
        [HttpPost]
        public async Task<HttpResultObject> UpdateFilename(UploadFile uploadFile)
        {
            try
            {
                var result = await _userService.Value.UpdateFilename(uploadFile);
                if (result != 0)
                    return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
                else
                    return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = 0, Message = "NotOK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
        [HttpPost]
        public async Task<HttpResultObject> ChangePassword(ChangePassword changePassword)
        {
            try
            {
                var result = await _userService.Value.ChangePassword(changePassword);
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
        [HttpPost]
        public async Task<HttpResultObject> DeleteEducation(DeleteEducation deleteEducation)
        {
            try
            {
                var result = await _userService.Value.DeleteEducation(deleteEducation);
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
        [HttpPost]
        public void Sendmail(MailParam mailService)
        {
            mailService.Attachments = @"D:\5337.xml";
            _mailService.Value.SendMail(mailService);
        }
    }
}

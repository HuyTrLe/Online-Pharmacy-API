using Microsoft.AspNetCore.Mvc;
using pj3_api.Model;
using pj3_api.Model.Career;
using pj3_api.Service.Home;
using pj3_api.Service.Mail;
using pj3_api.Service.User;
using System.Net;

namespace pj3_api.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class CareerController : ControllerBase
    {
        private readonly Lazy<ICareerService> _careerService;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<AppSettings> _appSetting;
        public CareerController(ICareerService careerService, IMailService mailService, IUserService userService, AppSettings appSettings)
        {
            _careerService = new Lazy<ICareerService>(() => careerService);
            _mailService = new Lazy<IMailService>(() => mailService);
            _userService = new Lazy<IUserService>(() => userService);
            _appSetting = new Lazy<AppSettings>(() => appSettings);
        }

        [HttpGet]
        public async Task<HttpResultObject> GetCareer()
        {
            var result = await _careerService.Value.GetCareer();
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpGet]
        public async Task<HttpResultObject> GetAllCareer()
        {
            var result = await _careerService.Value.GetAllCareer();
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpPost]
        public async Task<HttpResultObject> GetCareerByID(CareerGet careerGet)
        {
            var result = await _careerService.Value.GetCareerByID(careerGet);
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpGet]
        public async Task<HttpResultObject> GetCareerJob( )
        {
            var result = await _careerService.Value.GetCareerJob();
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpGet]
        public async Task<HttpResultObject> GetCareerJobAdmin()
        {
            var result = await _careerService.Value.GetCareerJobAdmin();
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpPost]
        public async Task<HttpResultObject> GetCareerJobWithUser(CareerJobGet CareerJobGet)
        {
            var result = await _careerService.Value.GetCareerJobWithUser(CareerJobGet);
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpPost]
        public async Task<HttpResultObject> GetCareersByUserID(CareerGet CareerGet)
        {
            var result = await _careerService.Value.GetCareersByUserID(CareerGet);
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpPost]
        public async Task<HttpResultObject> InsertCareer(CareerModel CareerGet)
        {
            var result = await _careerService.Value.InsertCareer(CareerGet);
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpPost]
        public async Task<HttpResultObject> UpdateCareer(CareerModel CareerModel)
        {
            var result = await _careerService.Value.UpdateCareer(CareerModel);
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpPost]
        public async Task<HttpResultObject> GetCareerDetailByUserID(CareerGet CareerGet)
        {
            var result = await _careerService.Value.GetCareerDetailByUserID(CareerGet);
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpPost]
        public async Task<HttpResultObject> InsertCareerJob(CareerJobModel CareerJobModel)
        {
            var result = await _careerService.Value.InsertCareerJob(CareerJobModel);
            if(result > 0)
            {
                
                var user = await _userService.Value.GetUser(CareerJobModel.UserID);
                string filePath = System.IO.Path.Combine(_appSetting.Value.Path.ImagePath,user.UserModel.FileName);
                MailParam mailParam = new MailParam() {
                    ToAddress = "tutranit0101@gmail.com",
                    Subject = "New user apply job",
                    Body ="Hi admin," +"We have a User apply this job"+ "\r\n" + "Information of User: "+ "\r\n" + "User:" + user.UserModel.UserName + "\r\n" + "Email: "+ user.UserModel.Email + "\r\n" + "Phone Number: " +user.UserModel.PhoneNumber  + "\r\n\r\n" + "Thanks!",
                    Attachments = filePath
                };
                _mailService.Value.SendMail(mailParam);
            }
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
        [HttpPost]
        public async Task<HttpResultObject> UpdateCareerJob(CareerJobModel CareerJobModel)
        {
            var result = await _careerService.Value.UpdateCareerJob(CareerJobModel);
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
        }
    }
}

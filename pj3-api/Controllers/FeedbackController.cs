using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pj3_api.Model;
using pj3_api.Model.Feedback;
using pj3_api.Service.Feedback;
using pj3_api.Service.User;
using System.Net;

namespace pj3_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly Lazy<IFeedbackService> _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = new Lazy<IFeedbackService>(() => feedbackService);
        }

        [HttpPost]
        public async Task<HttpResultObject> GetFeedback()
        {
            try
            {
                var result = await _feedbackService.Value.GetFeedback();
                return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }

        [HttpPost]
        public async Task<HttpResultObject> InsertFeedback(FeedbackModel feedback)
        {
            try
            {
                var result = await _feedbackService.Value.InsertFeedback(feedback);
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

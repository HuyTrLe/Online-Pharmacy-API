using Microsoft.AspNetCore.Mvc;
using pj3_api.Model;
using pj3_api.Model.Specification;
using pj3_api.Service.Specification;
using System.Net;

namespace pj3_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SpecificationController : ControllerBase
    {
        private readonly Lazy<ISpecificationService> _SpecificationService;
        public SpecificationController(ISpecificationService SpecificationService)
        {
            _SpecificationService = new Lazy<ISpecificationService>(() => SpecificationService);
        }
        [HttpPost]
        public async Task<HttpResultObject> GetSpecification()
        {
            try
            {
                var result = await _SpecificationService.Value.GetSpecification();
                return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
        [HttpPost]
        public async Task<HttpResultObject> InsertSpecification(Model.Specification.SpecificationModel Specification)
        {
            try
            {
                var result = await _SpecificationService.Value.InsertSpecification(Specification);
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
        public async Task<HttpResultObject> UpdateSpecification(Model.Specification.SpecificationModel Specification)
        {
            try
            {
                var result = await _SpecificationService.Value.UpdateSpecification(Specification);
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
        [HttpGet]
        [Route("{ID:int}")] // Define a route constraint for the ID parameter
        public async Task<HttpResultObject> GetSpecificationById(int ID)
        {
            try
            {
                SpecificationModel specification = new SpecificationModel { ID = ID }; // Create a SpecificationModel instance with the ID
                var result = await _SpecificationService.Value.GetSpecificationByID(specification);
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

    }
}

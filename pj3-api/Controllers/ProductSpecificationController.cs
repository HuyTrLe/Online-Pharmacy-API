using Microsoft.AspNetCore.Mvc;
using pj3_api.Model.ProductSpecification;
using pj3_api.Model;
using System.Net;
using pj3_api.Service.ProductSpecification;
using pj3_api.Model.ProductImage;

namespace pj3_api.Controllers
{
    
        [ApiController]
        [Route("[controller]/[action]")]
        public class ProductSpecificationController : ControllerBase
        {
            private readonly Lazy<IProductSpecificationService> _ProductSpecificationService;
            public ProductSpecificationController(IProductSpecificationService ProductSpecificationService)
            {
            _ProductSpecificationService = new Lazy<IProductSpecificationService>(() => ProductSpecificationService);
            }
            [HttpPost]
            public async Task<HttpResultObject> GetProductSpecification()
            {
                try
                {
                    var result = await _ProductSpecificationService.Value.GetProductSpecification();
                    return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
                }
                catch (Exception ex)
                {
                    return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
                }

            }
            [HttpPost]
            public async Task<HttpResultObject> InsertProductSpecification(ProductSpecificationModel ProductSpecification)
            {
                try
                {
                    var result = await _ProductSpecificationService.Value.InsertProductSpecification(ProductSpecification);
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
            public async Task<HttpResultObject> UpdateProductSpecification(ProductSpecificationModel ProductSpecification)
            {
                try
                {
                    var result = await _ProductSpecificationService.Value.UpdateProductSpecification(ProductSpecification);
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
            public async Task<HttpResultObject> GetProductSpecificationByID(ProductSpecGet ProductSpecification)
            {
                try
                {
                    var result = await _ProductSpecificationService.Value.GetProductSpecificationByID(ProductSpecification);
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
            public async Task<HttpResultObject> DeleteProductSpecification(ProductSpecificationModel ProductSpecification)
            {
                try
                {
                    var result = await _ProductSpecificationService.Value.DeleteProductSpecification(ProductSpecification);
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
        public async Task<HttpResultObject> CheckSpecName(ProductSpecificationModel ProductSpecification)
        {
            var result = await _ProductSpecificationService.Value.CheckSpecName(ProductSpecification);
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };

        }


        [HttpPost]
        public async Task<HttpResultObject> CheckSpecCount(ProductSpecificationModel ProductSpecification)
        {
            try
            {
                var result = await _ProductSpecificationService.Value.CheckSpecCount(ProductSpecification);
                return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
    }
    
}

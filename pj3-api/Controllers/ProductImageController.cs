using Microsoft.AspNetCore.Mvc;
using pj3_api.Model;
using pj3_api.Model.ProductImage;
using pj3_api.Service.ProductImage;
using System.Net;

namespace pj3_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductImageController : ControllerBase
    {
        private readonly Lazy<IProductImageService> _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = new Lazy<IProductImageService>(() => productImageService);
        }
        [HttpGet]
        public async Task<HttpResultObject> GetProductImage()
        {
            try
            {
                var result = await _productImageService.Value.GetProductImage();
                return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
        [HttpPost]
        public async Task<HttpResultObject> InsertProductImage(ProductImageModel ProductImage)
        {
            try
            {
                var result = await _productImageService.Value.InsertProductImage(ProductImage);
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
        public async Task<HttpResultObject> UpdateProductImage(ProductImageModel ProductImage)
        {
            try
            {
                var result = await _productImageService.Value.UpdateProductImage(ProductImage);
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
        public async Task<HttpResultObject> GetProductImageByID(ProductImageModel ProductImage)
        {
            try
            {
                var result = await _productImageService.Value.GetProductImageByID(ProductImage);
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

﻿using Microsoft.AspNetCore.Mvc;
using pj3_api.Model;
using pj3_api.Model.Product;
using pj3_api.Service.Product;
using System.Net;

namespace pj3_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly Lazy<IProductService> _productService;
        public ProductController(IProductService productService)
        {
            _productService = new Lazy<IProductService>(() => productService);
        }
        [HttpGet]
        public async Task<HttpResultObject> GetProduct()
        {
            try
            {
                var result = await _productService.Value.GetProduct();
                return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };
            }
            catch (Exception ex)
            {
                return new HttpResultObject() { Code = HttpStatusCode.InternalServerError, Status = "NotOK", Data = "", Message = "NotOK" };
            }

        }
        [HttpPost]
        public async Task<HttpResultObject> InsertProduct(Model.Product.ProductModel product)
        {
            try
            {
                var result = await _productService.Value.InsertProduct(product);
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
        public async Task<HttpResultObject> UpdateProduct(Model.Product.ProductModel product)
        {
            try
            {
                var result = await _productService.Value.UpdateProduct(product);
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
        public async Task<HttpResultObject> GetProductByID(ProductGet product)
        {
            try
            {
                var result = await _productService.Value.GetProductByID(product);
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
		public async Task<HttpResultObject> GetProductByCategoryID(ProductGet product)
		{
			try
			{
				var result = await _productService.Value.GetProductByCategoryID(product);
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
        public async Task<HttpResultObject> CheckUniqueByName(ProductModel product)
        {
            var result = await _productService.Value.CheckUniqueByName(product);
            return new HttpResultObject() { Code = HttpStatusCode.OK, Status = "OK", Data = result, Message = "OK" };

        }

    }
}

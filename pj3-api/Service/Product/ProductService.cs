﻿using pj3_api.Model.Product;
using pj3_api.Repository.Product;

namespace pj3_api.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly Lazy<IProductRepository> _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = new Lazy<IProductRepository>(() => productRepository);
        }


        public Task<int> DeleteProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetProduct()
        {
            var result = await _productRepository.Value.GetProduct();
            return result;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByID(ProductModel product)
        {
            var result = await _productRepository.Value.GetProductByID(product);
            return result;
        }

        public async Task<int> InsertProduct(ProductModel product)
        {
            var result = await _productRepository.Value.InsertProduct(product);
            return result;
        }

        public async Task<int> UpdateProduct(ProductModel product)
        {
            var result = await _productRepository.Value.UpdateProduct(product);
            return result;
        }
    }
}
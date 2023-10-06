using pj3_api.Model.Product;
using pj3_api.Repository.Product;
using pj3_api.Repository.User;

namespace pj3_api.Service.Product
{
    public class ProductService : IProducttService
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

        public async Task<IEnumerable<ProductModel>> GetProductById(ProductModel product)
        {
            var result = await _productRepository.Value.GetProductById(product);
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

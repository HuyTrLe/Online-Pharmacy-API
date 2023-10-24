using pj3_api.Model.ProductSpecification;
using pj3_api.Repository.ProductSpecification;
using pj3_api.Repository.User;

namespace pj3_api.Service.ProductSpecification
{
    public class ProductSpecificationService : IProductSpecificationService
    {
        private readonly Lazy<IProductSpecificationRepository> _ProductSpecificationRepository;
        public ProductSpecificationService(IProductSpecificationRepository productRepository)
        {
            _ProductSpecificationRepository = new Lazy<IProductSpecificationRepository>(() => productRepository);
        }


        public async Task<int> DeleteProductSpecification(ProductSpecificationModel product)
        {
            var result = await _ProductSpecificationRepository.Value.DeleteProductSpecification(product);
            return result;
        }

        public async Task<IEnumerable<ProductSpecificationModel>> GetProductSpecification()
        {
            var result = await _ProductSpecificationRepository.Value.GetProductSpecification();
            return result;
        }

        public async Task<IEnumerable<ProductSpecificationModel>> GetProductSpecificationByID(ProductSpecificationModel product)
        {
            var result = await _ProductSpecificationRepository.Value.GetProductSpecificationByID(product);
            return result;
        }

        public async Task<int> InsertProductSpecification(ProductSpecificationModel product)
        {
            var result = await _ProductSpecificationRepository.Value.InsertProductSpecification(product);
            return result;
        }

        public async Task<int> UpdateProductSpecification(ProductSpecificationModel product)
        {
            var result = await _ProductSpecificationRepository.Value.UpdateProductSpecification(product);
            return result;
        }
    }
}

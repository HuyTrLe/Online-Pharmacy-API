using pj3_api.Model.Product;
using pj3_api.Model.ProductImage;
using pj3_api.Model.ProductSpecification;

namespace pj3_api.Service.ProductSpecification
{
    public interface IProductSpecificationService
    {
        Task<IEnumerable<ProductSpecificationModel>> GetProductSpecification();

        Task<int> InsertProductSpecification(ProductSpecificationModel product);
        Task<int> UpdateProductSpecification(ProductSpecificationModel product);

        Task<int> DeleteProductSpecification(ProductSpecificationModel product);

        Task<ProductSpecificationModel> GetProductSpecificationByID(ProductSpecGet product);

        Task<ProductSpecificationModel> CheckSpecName(ProductSpecificationModel product);

        Task<IEnumerable<ProductSpecificationModel>> CheckSpecCount(ProductSpecificationModel product);

        Task<IEnumerable<ProductSpecificationModel>> GetProductSpecificationByID(ProductSpecificationModel product);
    }
}

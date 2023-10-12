using pj3_api.Model.ProductSpecification;

namespace pj3_api.Repository.ProductSpecification
{
    public interface IProductSpecificationRepository
    {
        Task<IEnumerable<ProductSpecificationModel>> GetProductSpecification();

        Task<int> InsertProductSpecification(ProductSpecificationModel product);
        Task<int> UpdateProductSpecification(ProductSpecificationModel product);

        Task<int> DeleteProductSpecification(ProductSpecificationModel product);

        Task<IEnumerable<ProductSpecificationModel>> GetProductSpecificationByID(ProductSpecificationModel product);
    }
}

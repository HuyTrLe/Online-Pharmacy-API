using pj3_api.Model.Product;

namespace pj3_api.Service.Product
{
    public interface IProducttService
    {
        Task<IEnumerable<ProductModel>> GetProduct();

        Task<int> InsertProduct(ProductModel product);
        Task<int> UpdateProduct(ProductModel product);

        Task<int> DeleteProduct(ProductModel product);

        Task<IEnumerable<ProductModel>> GetProductById(ProductModel product);
    }
}

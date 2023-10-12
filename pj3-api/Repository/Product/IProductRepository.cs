
using pj3_api.Model.Product;

namespace pj3_api.Repository.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetProduct();

        Task<int> InsertProduct(ProductModel product);
        Task<int> UpdateProduct(ProductModel product);

        Task<int> DeleteProduct(ProductModel product);

        Task<IEnumerable<ProductModel>> GetProductByID(ProductModel product);
    }
}

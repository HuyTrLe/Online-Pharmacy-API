using pj3_api.Model.ProductImage;

namespace pj3_api.Repository.ProductImage
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImageModel>> GetProductImage();

        Task<int> InsertProductImage(ProductImageModel ProductImage);
        Task<int> UpdateProductImage(ProductImageModel ProductImage);

        Task<int> DeleteProductImage(ProductImageModel ProductImage);

        Task<IEnumerable<ProductImageModel>> CheckProductImage(ProductImageModel ProductImage);

        Task<IEnumerable<ProductImageModel>> GetProductImageByID(ProductImageModel productImage);
    }
}

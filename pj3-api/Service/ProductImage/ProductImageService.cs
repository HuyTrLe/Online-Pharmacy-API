using pj3_api.Model.ProductImage;
using pj3_api.Repository.ProductImage;

namespace pj3_api.Service.ProductImage
{
    public class ProductImageService : IProductImageService
    {
        private readonly Lazy<IProductImageRepository> _ProductImageRepository;
        public ProductImageService(IProductImageRepository ProductImageRepository)
        {
            _ProductImageRepository = new Lazy<IProductImageRepository>(() => ProductImageRepository);
        }

        public async Task<IEnumerable<ProductImageModel>> CheckProductImage(ProductImageModel ProductImage)
        {
            var result = await _ProductImageRepository.Value.CheckProductImage(ProductImage);
            return result;
        }

        public async Task<int> DeleteProductImage(ProductImageModel ProductImage)
        {
            var result = await _ProductImageRepository.Value.DeleteProductImage(ProductImage);
            return result;
        }

        public async Task<IEnumerable<ProductImageModel>> GetProductImage()
        {
            var result = await _ProductImageRepository.Value.GetProductImage();
            return result;
        }

        public async Task<IEnumerable<ProductImageModel>> GetProductImageByID(ProductImageModel ProductImage)
        {
            var result = await _ProductImageRepository.Value.GetProductImageByID(ProductImage);
            return result;
        }

        public async Task<int> InsertProductImage(ProductImageModel ProductImage)
        {
            var result = await _ProductImageRepository.Value.InsertProductImage(ProductImage);
            return result;
        }

        public async Task<int> UpdateProductImage(ProductImageModel ProductImage)
        {
            var result = await _ProductImageRepository.Value.UpdateProductImage(ProductImage);
            return result;
        }
     

        

       
    }
}

using pj3_api.Database;
using pj3_api.Model;
using pj3_api.Model.ProductImage;
using pj3_api.Repository.Feedback;
using pj3_api.Repository.Specification;
using System.Data;

namespace pj3_api.Repository.ProductImage
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public ProductImageRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }

        public async Task<IEnumerable<ProductImageModel>> CheckProductImage(ProductImageModel ProductImage)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ProductID", ProductImage.ProductID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<ProductImageModel>(ProductImageQuery.CheckProductImage, parameters);
            return result;
        }

        public async Task<int> DeleteProductImage(ProductImageModel ProductImage)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", ProductImage.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Delete(ProductImageQuery.DeleteImage, parameters);
            return result;
        }

       

        public async Task<IEnumerable<ProductImageModel>> GetProductImage()
        {
            var result = await _sqlQueryDataSource.Value.Select<ProductImageModel>(ProductImageQuery.GetProductImage, null);
            return result;
        }

        public async Task<IEnumerable<ProductImageModel>> GetProductImageByID(ProductImageModel ProductImage)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", ProductImage.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<ProductImageModel>(ProductImageQuery.GetProductImagebyID, parameters);
            return result;
        }

       

        public async Task<int> InsertProductImage(ProductImageModel ProductImage)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ProductID", ProductImage.ProductID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Image", ProductImage.Image, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ID", ProductImage.ID, SqlDbType.Int, ParameterDirection.Output);


            var result = await _sqlQueryDataSource.Value.Insert(ProductImageQuery.InsertProductImage, parameters);
            int newID = parameters.Get<int>("@ID");
            return newID;
        }

       

        public async Task<int> UpdateProductImage(ProductImageModel ProductImage)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", ProductImage.ID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@ProductID", ProductImage.ProductID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Image", ProductImage.Image, SqlDbType.NVarChar, ParameterDirection.Input);

            var result = await _sqlQueryDataSource.Value.Update(ProductImageQuery.UpdateProductImage, parameters);
            return result;
        }
    }
}

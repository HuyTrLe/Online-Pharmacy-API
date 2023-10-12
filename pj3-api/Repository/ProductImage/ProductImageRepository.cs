using pj3_api.Database;
using pj3_api.Model;
using pj3_api.Model.ProductImage;
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


        public Task<int> DeleteProductImage(ProductImageModel ProductImage)
        {
            throw new NotImplementedException();
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
            parameters.Add("@ID", ProductImage.ID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@ProductID", ProductImage.ProductID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Image", ProductImage.Image, SqlDbType.NVarChar, ParameterDirection.Input);


            var result = await _sqlQueryDataSource.Value.Insert(ProductImageQuery.InsertProductImage, parameters);
            return result;
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

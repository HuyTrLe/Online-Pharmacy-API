using pj3_api.Database;
using pj3_api.Model;
using pj3_api.Model.Product;
using pj3_api.Model.Specification;
using pj3_api.Repository.Specification;
using System.Data;

namespace pj3_api.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public ProductRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }

        public async Task<ProductModel> CheckUniqueByName(ProductModel product)
        {
            try
            {
                MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
                parameters.Add("@Name", product.Name, SqlDbType.NChar, ParameterDirection.Input);
                var result = await _sqlQueryDataSource.Value.First<ProductModel>(ProductQuery.CheckUniqueByName, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> DeleteProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetProduct()
        {
            var result = await _sqlQueryDataSource.Value.Select<ProductModel>(ProductQuery.GetProduct, null);
            return result;
        }


        public async Task<int> InsertProduct(ProductModel product)
        {
            try
            {
                MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
                parameters.Add("@CategoryID", product.CategoryID, SqlDbType.Int, ParameterDirection.Input);
                parameters.Add("@Name", product.Name, SqlDbType.NVarChar, ParameterDirection.Input);
                parameters.Add("@Thumbnail", product.Thumbnail, SqlDbType.NVarChar, ParameterDirection.Input);
                parameters.Add("@Description", product.Description, SqlDbType.NVarChar, ParameterDirection.Input);
                parameters.Add("@ID", product.ID, SqlDbType.Int, ParameterDirection.Output);

                var result = await _sqlQueryDataSource.Value.Insert(ProductQuery.InsertProduct, parameters);
                int newID = parameters.Get<int>("@ID");
                return newID;
            }
            catch (Exception ex)
            {
                throw ex;
                return 0;
            }

        }

        public async Task<int> UpdateProduct(ProductModel product)
        {
            try
            {
                MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
                parameters.Add("@CategoryID", product.CategoryID, SqlDbType.Int, ParameterDirection.Input);
                parameters.Add("@Name", product.Name, SqlDbType.NVarChar, ParameterDirection.Input);
                parameters.Add("@Thumbnail", product.Thumbnail, SqlDbType.NVarChar, ParameterDirection.Input);
                parameters.Add("@Description", product.Description, SqlDbType.NVarChar, ParameterDirection.Input);
                parameters.Add("@Deleted", product.Deleted, SqlDbType.Bit, ParameterDirection.Input);
                parameters.Add("@ID", product.ID, SqlDbType.Int, ParameterDirection.Input);

                var result = await _sqlQueryDataSource.Value.Update(ProductQuery.UpdateProduct, parameters);
                int newID = parameters.Get<int>("@ID");

                return newID;

            }
            catch (Exception ex)
            {
                throw ex;
                return 0;
            }
        }




        public async Task<ProductModel> GetProductByID(ProductGet product)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", product.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.First<ProductModel>(ProductQuery.GetProductbyID, parameters);
            return result;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategoryID(ProductGet product)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@CategoryID", product.CategoryID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<ProductModel>(ProductQuery.GetProductbyCategoryID, parameters);
            return result;
        }

        public Task<IEnumerable<ProductModel>> GetProductByID(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}



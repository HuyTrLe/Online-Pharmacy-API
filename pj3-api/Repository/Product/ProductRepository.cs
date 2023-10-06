﻿using pj3_api.Database;
using pj3_api.Model;
using pj3_api.Model.Product;
using pj3_api.Model.User;
using pj3_api.Repository.User;
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

        public Task<int> DeleteProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetProduct()
        {
            var result = await _sqlQueryDataSource.Value.Select<ProductModel>(ProductQuery.GetProduct, null);
            return result;
        }

        public async Task<IEnumerable<ProductModel>> GetProductById(ProductModel product)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", product.ID, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<ProductModel>(ProductQuery.GetProductbyID, parameters);
            return result;
        }

        public async Task<int> InsertProduct(ProductModel product)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", product.ID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@CategoryID", product.CategoryID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Name", product.Name, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Thumbnail", product.Thumbnail, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Description", product.Description, SqlDbType.NVarChar, ParameterDirection.Input);

            var result = await _sqlQueryDataSource.Value.Insert(ProductQuery.InsertProduct, parameters);
            return result;
        }

        public async Task<int> UpdateProduct(ProductModel product)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", product.ID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@CategoryID", product.CategoryID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Name", product.Name, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Thumbnail", product.Thumbnail, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Description", product.Description, SqlDbType.NVarChar, ParameterDirection.Input);

            var result = await _sqlQueryDataSource.Value.Update(ProductQuery.UpdateProduct, parameters);
            return result;
        }
    }
}

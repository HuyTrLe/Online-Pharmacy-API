﻿using pj3_api.Database;
using pj3_api.Model;
using pj3_api.Model.ProductSpecification;
using pj3_api.Model.User;
using pj3_api.Repository.User;
using System.Data;

namespace pj3_api.Repository.ProductSpecification
{
    public class ProductSpecificationRepository : IProductSpecificationRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public ProductSpecificationRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }

        public Task<int> DeleteProductSpecification(ProductSpecificationModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductSpecificationModel>> GetProductSpecification()
        {
            var result = await _sqlQueryDataSource.Value.Select<ProductSpecificationModel>(ProductSpecificationQuery.GetProductSpecification, null);
            return result;
        }

        public async Task<IEnumerable<ProductSpecificationModel>> GetProductSpecificationByID(ProductSpecificationModel product)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", product.ID, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<ProductSpecificationModel>(ProductSpecificationQuery.GetProductSpecificationByID, parameters);
            return result;
        }

        public async Task<int> InsertProductSpecification(ProductSpecificationModel product)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ProductID", product.ProductID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@SpecID", product.SpecID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@SpecName", product.SpecName, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@SpecValue", product.SpecValue, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@SpecUnit", product.SpecUnit, SqlDbType.NVarChar, ParameterDirection.Input);

            parameters.Add("@ID", product.ID, SqlDbType.Int, ParameterDirection.Output);
            var result = await _sqlQueryDataSource.Value.Insert(ProductSpecificationQuery.InsertProductSpecification, parameters);
            int newID = parameters.Get<int>("@ID");
            return newID;
        }

        public async Task<int> UpdateProductSpecification(ProductSpecificationModel product)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", product.ID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ProductID", product.ProductID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@SpecID", product.SpecID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@SpecName", product.SpecName, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@SpecValue", product.SpecValue, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@SpecUnit", product.SpecUnit, SqlDbType.NVarChar, ParameterDirection.Input);

            var result = await _sqlQueryDataSource.Value.Update(ProductSpecificationQuery.UpdateProductSpecification, parameters);
            return result;
        }
    }
}
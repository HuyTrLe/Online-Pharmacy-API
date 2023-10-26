using pj3_api.Database;
using pj3_api.Model.Specification;
using pj3_api.Model;
using pj3_api.Repository.Specification;
using System.Data;
using pj3_api.Repository.ProductSpecification;
using pj3_api.Model.Career;
using pj3_api.Repository.Career;

namespace pj3_api.Repository.Specification
{
    public class SpecificationRepository : ISpecificationRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public SpecificationRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }

        public async Task<SpecificationModel> CheckUniqueByName(SpecificationModel Specification)
        {
            try
            {
                MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
                parameters.Add("@Name", Specification.Name, SqlDbType.NChar, ParameterDirection.Input);
                var result = await _sqlQueryDataSource.Value.First<SpecificationModel>(SpecificationQuery.CheckUniqueByName, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> DeleteSpecification(SpecificationModel Specification)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", Specification.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Delete(SpecificationQuery.DeleteSpecification, parameters);
            return result;
        }

        public async Task<IEnumerable<SpecificationModel>> GetSpecification()
        {
            var result = await _sqlQueryDataSource.Value.Select<SpecificationModel>(SpecificationQuery.GetSpecification, null);
            return result;
        }

        public async Task<IEnumerable<SpecificationModel>> GetSpecificationByID(SpecificationModel Specification)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", Specification.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<SpecificationModel>(SpecificationQuery.GetSpecificationByID, parameters);
            return result;
        }

        public async Task<int> InsertSpecification(SpecificationModel Specification)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", Specification.ID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Name", Specification.Name, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Unit", Specification.Unit, SqlDbType.NVarChar, ParameterDirection.Input);


            parameters.Add("@ID", Specification.ID, SqlDbType.Int, ParameterDirection.Output);
            var result = await _sqlQueryDataSource.Value.Insert(SpecificationQuery.InsertSpecification, parameters);
            int newID = parameters.Get<int>("@ID");
            return newID;
           
         
        }

        public async Task<int> UpdateSpecification(SpecificationModel Specification)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", Specification.ID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Name", Specification.Name, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Unit", Specification.Unit, SqlDbType.NVarChar, ParameterDirection.Input);

            var result = await _sqlQueryDataSource.Value.Update(SpecificationQuery.UpdateSpecification, parameters);
            return result;
        }
    }
}

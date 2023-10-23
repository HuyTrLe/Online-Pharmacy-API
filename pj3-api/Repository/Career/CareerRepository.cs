using pj3_api.Database;
using pj3_api.Model;
using pj3_api.Model.Career;
using pj3_api.Model.User;
using pj3_api.Repository.User;
using System.Data;

namespace pj3_api.Repository.Career
{
    public class CareerRepository : ICareerRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public CareerRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }
        public async Task<int> UpdateFilename(UploadFile user)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserID", user.UserID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@FileName", user.Filename, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Update(UserQuery.UpdateFilename, parameters);
            return result;
        }

        public async Task<IEnumerable<CareerModel>> GetCareer()
        {
            var result = await _sqlQueryDataSource.Value.Select<CareerModel>(CareerQuery.GetCareer, null);
            return result;
        }

        public async Task<CareerModel> GetCareerByID(CareerGet CareerGet)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", CareerGet.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.First<CareerModel>(CareerQuery.GetCareerByID, parameters);
            return result;
        }

        public async Task<int> InsertCareer(CareerModel CareerModel)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@Title", CareerModel.Title, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ShortDescription", CareerModel.ShortDescription, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Description", CareerModel.Description, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@TimeStart", CareerModel.TimeStart, SqlDbType.DateTime, ParameterDirection.Input);
            parameters.Add("@TimeEnd", CareerModel.TimeEnd, SqlDbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Position", CareerModel.Position, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Price", CareerModel.Price, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Skill", CareerModel.Skill, SqlDbType.VarChar, ParameterDirection.Input);
            parameters.Add("@Status", CareerModel.Status, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@ID", CareerModel.ID, SqlDbType.Int, ParameterDirection.Output);
            var result = await _sqlQueryDataSource.Value.Insert(CareerQuery.InsertCareer, parameters);
            int newID = parameters.Get<int>("@ID");
            return newID;
        }


        public async Task<int> UpdateCareer(CareerModel CareerModel)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@Title", CareerModel.Title, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ShortDescription", CareerModel.ShortDescription, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Description", CareerModel.Description, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@TimeStart", CareerModel.TimeStart, SqlDbType.DateTime, ParameterDirection.Input);
            parameters.Add("@TimeEnd", CareerModel.TimeEnd, SqlDbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Position", CareerModel.Position, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Price", CareerModel.Price, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Skill", CareerModel.Skill, SqlDbType.VarChar, ParameterDirection.Input);
            parameters.Add("@Status", CareerModel.Status, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@ID", CareerModel.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Update(CareerQuery.UpdateCareer, parameters);
            return result;
        }

        public async Task<int> DeleteCareer(CareerModel CareerModel)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@Status", CareerModel.Status, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@ID", CareerModel.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Update(CareerQuery.UpdateStatus, parameters);
            return result;
        }

        public async Task<IEnumerable<CareerJobModel>> GetCareerJob()
        {
            var result = await _sqlQueryDataSource.Value.Select<CareerJobModel>(CareerQuery.SelectCareerJob, null);
            return result;
        }

        public async Task<IEnumerable<CareerJobModel>> GetCareerJobWithUser(CareerJobGet CareerJobGet)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserID", CareerJobGet.UserID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<CareerJobModel>(CareerQuery.SelectCareerJob, parameters);
            return result;
        }

        public async Task<int> InsertCareerJob(CareerJobModel CareerJobModel)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@JobID", CareerJobModel.JobID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@UserID", CareerJobModel.UserID, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Status", 0, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Insert(CareerQuery.InsertCareerJob, parameters);
            return result;
        }

        public async Task<int> UpdateCareerJob(CareerJobModel CareerJobModel)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@Status", CareerJobModel.Status, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ID", CareerJobModel.ID, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Insert(CareerQuery.UpdateCareer, parameters);
            return result;
        }

        public async Task<IEnumerable<CareerModel>> GetCareersByUserID(CareerGet CareerGet)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserID", CareerGet.UserID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<CareerModel>(CareerQuery.GetCareersByUserID, parameters);
            return result;
        }

        public async Task<CareerModel> GetCareerDetailByUserID(CareerGet CareerGet)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@UserID", CareerGet.UserID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@ID", CareerGet.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.First<CareerModel>(CareerQuery.GetCareersDetailByUserID, parameters);
            return result;
        }
    }
}

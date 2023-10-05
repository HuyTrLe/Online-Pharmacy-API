using pj3_api.Database;
using pj3_api.Model;
using pj3_api.Model.Feedback;
using pj3_api.Model.User;
using pj3_api.Repository.User;
using System.Data;

namespace pj3_api.Repository.Feedback
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public FeedbackRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }
        public async Task<IEnumerable<FeedbackModel>> GetFeedback()
        {
            var result = await _sqlQueryDataSource.Value.Select<FeedbackModel>(FeedbackQuery.GetFeedback, null);
            return result;
        }

        public async Task<int> InsertFeedback(FeedbackModel feedback)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@FullName", feedback.FullName, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@CompanyName", feedback.CompanyName, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Email", feedback.Email, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@PhoneNumber", feedback.PhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Subject", feedback.Subject, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Comment", feedback.Comment, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ID", feedback.ID, SqlDbType.Int, ParameterDirection.Output);
            var result = await _sqlQueryDataSource.Value.Insert(FeedbackQuery.InsertFeedback, parameters);
            int newID = parameters.Get<int>("@ID");
            return newID;
        }
    }
}

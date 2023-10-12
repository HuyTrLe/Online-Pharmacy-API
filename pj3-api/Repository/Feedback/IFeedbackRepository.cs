using pj3_api.Model.Feedback;

namespace pj3_api.Repository.Feedback
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<FeedbackModel>> GetFeedback();
        Task<int> InsertFeedback(FeedbackModel feedback);

        Task<IEnumerable<FeedbackModel>> GetFeedbackById(int ID);
    }
}

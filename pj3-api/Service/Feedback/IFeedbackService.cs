using pj3_api.Model.Feedback;
using pj3_api.Model.User;

namespace pj3_api.Service.Feedback
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackModel>> GetFeedback();
        Task<int> InsertFeedback(FeedbackModel feedback);
    }
}

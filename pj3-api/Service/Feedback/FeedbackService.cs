using pj3_api.Model.Feedback;
using pj3_api.Repository.Feedback;
using pj3_api.Repository.User;

namespace pj3_api.Service.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly Lazy<IFeedbackRepository> _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = new Lazy<IFeedbackRepository>(() => feedbackRepository);
        }
        public async Task<IEnumerable<FeedbackModel>> GetFeedback()
        {
            var result = await _feedbackRepository.Value.GetFeedback();
            return result;
        }

        public async Task<int> InsertFeedback(FeedbackModel feedback)
        {
            var result = await _feedbackRepository.Value.InsertFeedback(feedback);
            return result;
        }
    }
}

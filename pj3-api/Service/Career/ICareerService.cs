using pj3_api.Model;
using pj3_api.Model.Career;
using pj3_api.Model.User;

namespace pj3_api.Service.User
{
    public interface ICareerService
    {
        Task<IEnumerable<CareerModel>> GetCareer();
        Task<IEnumerable<CareerModel>> GetAllCareer();
        Task<IEnumerable<CareerModel>> GetCareersByUserID(CareerGet CareerGet);

        Task<CareerModel> GetCareerByID(CareerGet CareerGet);
        Task<CareerModel> GetCareerDetailByUserID(CareerGet CareerGet);
        Task<IEnumerable<CareerJob>> GetCareerJobAdmin();

        Task<int> InsertCareer(CareerModel CareerModel);
        Task<int> UpdateCareer(CareerModel CareerModel);
        Task<int> DeleteCareer(CareerModel CareerModel);
        Task<IEnumerable<CareerJobModel>> GetCareerJob();
        Task<IEnumerable<CareerJobModel>> GetCareerJobWithUser(CareerJobGet CareerJobGet);
        Task<int> InsertCareerJob(CareerJobModel CareerJobModel);
        Task<int> UpdateCareerJob(CareerJobModel CareerJobModel);
        Task<int> UpdateStatusCareerJob(UpdateStatusCareerJob UpdateStatusCareerJob);
    }
}

using pj3_api.Model;
using pj3_api.Model.Career;
using pj3_api.Model.User;
using pj3_api.Repository.Career;
using pj3_api.Repository.User;
using System.Data;

namespace pj3_api.Service.User
{
    public class CareerService : ICareerService
    {
        private readonly Lazy<ICareerRepository> _careerRepository;
        public CareerService(ICareerRepository careerRepository) {
            _careerRepository = new Lazy<ICareerRepository>(() => careerRepository);
        }

        public async Task<int> DeleteCareer(CareerModel CareerModel)
        {
            var result = await _careerRepository.Value.DeleteCareer(CareerModel);
            return result;
        }

        public async Task<IEnumerable<CareerModel>> GetCareer()
        {
            var result = await _careerRepository.Value.GetCareer();
            return result;
        }

        public async Task<CareerModel> GetCareerByID(CareerGet CareerGet)
        {
            var result = await _careerRepository.Value.GetCareerByID(CareerGet);
            return result;
        }

        public async Task<CareerModel> GetCareerDetailByUserID(CareerGet CareerGet)
        {
            var result = await _careerRepository.Value.GetCareerDetailByUserID(CareerGet);
            return result;
        }

        public async Task<IEnumerable<CareerJobModel>> GetCareerJob()
        {
            var result = await _careerRepository.Value.GetCareerJob();
            return result;
        }

        public async Task<IEnumerable<CareerJobModel>> GetCareerJobWithUser(CareerJobGet CareerJobGet)
        {
            var result = await _careerRepository.Value.GetCareerJobWithUser(CareerJobGet);
            return result;
        }

        public async Task<IEnumerable<CareerModel>> GetCareersByUserID(CareerGet CareerGet)
        {
            var result = await _careerRepository.Value.GetCareersByUserID(CareerGet);
            return result;
        }

        public async Task<int> InsertCareer(CareerModel CareerModel)
        {
            var result = await _careerRepository.Value.InsertCareer(CareerModel);
            return result;
        }

        public async Task<int> InsertCareerJob(CareerJobModel CareerJobModel)
        {
            var result = await _careerRepository.Value.InsertCareerJob(CareerJobModel);
            return result;
        }

        public async Task<int> UpdateCareer(CareerModel CareerModel)
        {
            var result = await _careerRepository.Value.UpdateCareer(CareerModel);
            return result;
        }

        public async Task<int> UpdateCareerJob(CareerJobModel CareerJobModel)
        {
            var result = await _careerRepository.Value.UpdateCareerJob(CareerJobModel);
            return result;
        }
    }
}

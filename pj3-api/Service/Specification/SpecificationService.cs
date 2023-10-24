using pj3_api.Model.Specification;
using pj3_api.Repository.Specification;

namespace pj3_api.Service.Specification
{
    public class SpecificationService : ISpecificationService
    {
        private readonly Lazy<ISpecificationRepository> _specificationRepository;
        public SpecificationService(ISpecificationRepository SpecificationRepository)
        {
            _specificationRepository = new Lazy<ISpecificationRepository>(() => SpecificationRepository);
        }


        public async Task<int> DeleteSpecification(SpecificationModel Specification)
        {
            var result = await _specificationRepository.Value.DeleteSpecification(Specification);
            return result;
        }

        public async Task<SpecificationModel> CheckUniqueByName (SpecificationModel Specification)
        {
            try
            {
                var result = await _specificationRepository.Value.CheckUniqueByName(Specification);
                return result;

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SpecificationModel>> GetSpecification()
        {
            var result = await _specificationRepository.Value.GetSpecification();
            return result;
        }

        public async Task<IEnumerable<SpecificationModel>> GetSpecificationByID(SpecificationModel Specification)
        {
            var result = await _specificationRepository.Value.GetSpecificationByID(Specification);
            return result;
        }

        public async Task<int> InsertSpecification(SpecificationModel Specification)
        {
            var result = await _specificationRepository.Value.InsertSpecification(Specification);
            return result;
        }

        public async Task<int> UpdateSpecification(SpecificationModel Specification)
        {
            var result = await _specificationRepository.Value.UpdateSpecification(Specification);
            return result;
        }
    }
}

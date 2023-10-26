using pj3_api.Model.Specification;

namespace pj3_api.Service.Specification
{
    public interface ISpecificationService
    {
        Task<IEnumerable<SpecificationModel>> GetSpecification();

        Task<int> InsertSpecification(SpecificationModel Specification);
        Task<int> UpdateSpecification(SpecificationModel Specification);

        Task<int> DeleteSpecification(SpecificationModel Specification);

        Task<SpecificationModel> CheckUniqueByName(SpecificationModel Specification);

        Task<IEnumerable<SpecificationModel>> GetSpecificationByID(SpecificationModel Specification);
    }
}

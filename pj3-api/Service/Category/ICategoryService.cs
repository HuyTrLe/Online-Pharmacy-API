using pj3_api.Model.Category;

namespace pj3_api.Service.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategory();

        Task<int> InsertCategory(CategoryModel Category);
        Task<int> UpdateCategory(CategoryModel Category);

        Task<int> DeleteCategory(CategoryModel Category);

        Task<IEnumerable<CategoryModel>> GetCategoryById(CategoryModel Category);
    }
}

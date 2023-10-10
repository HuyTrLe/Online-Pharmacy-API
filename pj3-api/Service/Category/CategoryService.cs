using pj3_api.Model.Category;
using pj3_api.Model.Category;
using pj3_api.Repository.Category;

namespace pj3_api.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly Lazy<ICategoryRepository> _CategoryRepository;
        public CategoryService(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = new Lazy<ICategoryRepository>(() => CategoryRepository);
        }


        public Task<int> DeleteCategory(CategoryModel Category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryModel>> GetCategory()
        {
            var result = await _CategoryRepository.Value.GetCategory();
            return result;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryById(CategoryModel Category)
        {
            var result = await _CategoryRepository.Value.GetCategoryById(Category);
            return result;
        }

        public async Task<int> InsertCategory(CategoryModel Category)
        {
            var result = await _CategoryRepository.Value.InsertCategory(Category);
            return result;
        }

        public async Task<int> UpdateCategory(CategoryModel Category)
        {
            var result = await _CategoryRepository.Value.UpdateCategory(Category);
            return result;
        }
    }
}

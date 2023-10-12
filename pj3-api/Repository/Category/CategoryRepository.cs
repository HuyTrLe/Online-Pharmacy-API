using pj3_api.Database;
using pj3_api.Model;
using pj3_api.Model.Category;
using System.Data;

namespace pj3_api.Repository.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public CategoryRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }

        public Task<int> DeleteCategory(CategoryModel Category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryModel>> GetCategory()
        {
            var result = await _sqlQueryDataSource.Value.Select<CategoryModel>(CategoryQuery.GetCategory, null);
            return result;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryById(CategoryModel Category)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", Category.ID, SqlDbType.Int, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<CategoryModel>(CategoryQuery.GetCategorybyID, parameters);
            return result;
        }

        public async Task<int> InsertCategory(CategoryModel Category)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", Category.ID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Name", Category.Name, SqlDbType.NVarChar, ParameterDirection.Input);

            var result = await _sqlQueryDataSource.Value.Insert(CategoryQuery.InsertCategory, parameters);
            return result;
        }

        public async Task<int> UpdateCategory(CategoryModel Category)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID", Category.ID, SqlDbType.Int, ParameterDirection.Input);
            parameters.Add("@Name", Category.Name, SqlDbType.NVarChar, ParameterDirection.Input);

            var result = await _sqlQueryDataSource.Value.Update(CategoryQuery.UpdateCategory, parameters);
            return result;
        }
    }
}

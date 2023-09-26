using pj3_api.Database;
using pj3_api.Model;
using System.Data;

namespace pj3_api.Repository.Home
{
    public class HomeRepository : IHomeRepository
    {
        private readonly Lazy<MSSQLQueryDataSource> _sqlQueryDataSource;
        public HomeRepository(AppSettings appSettings)
        {
            _sqlQueryDataSource = new Lazy<MSSQLQueryDataSource>(() =>
                   new MSSQLQueryDataSource(appSettings.MSSQLSettings));
        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var result = await _sqlQueryDataSource.Value.Select<Movie>(HomeQuery.GetMovies,null);
            return result;
        }
        public async Task<IEnumerable<Movie>> GetMoviesByID(int ID)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@ID",ID, SqlDbType.NVarChar, ParameterDirection.Input);
            var result = await _sqlQueryDataSource.Value.Select<Movie>(HomeQuery.GetMoviesByID, parameters);
            return result;
        }
        public async Task<int> InsertMovie(Movie movie)
        {
            MSSQLDynamicParameters parameters = new MSSQLDynamicParameters();
            parameters.Add("@Name", movie.Name, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Description", movie.Description, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@Year", movie.Year, SqlDbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Image", movie.Image, SqlDbType.NVarChar, ParameterDirection.Input);
            parameters.Add("@ID", movie.ID, SqlDbType.Int, ParameterDirection.Output);
            var result = await _sqlQueryDataSource.Value.Insert(HomeQuery.InsertMovie, parameters);
            int newID = parameters.Get<int>("@ID");
            return newID;
        }
    }
}

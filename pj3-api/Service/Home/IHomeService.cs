using pj3_api.Model;

namespace pj3_api.Service.Home
{
    public interface IHomeService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<IEnumerable<Movie>> GetMoviesById(int ID);
        Task<int> InsertMovie(Movie movie);
    }
}

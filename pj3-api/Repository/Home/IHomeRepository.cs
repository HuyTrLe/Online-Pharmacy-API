using pj3_api.Model;

namespace pj3_api.Repository.Home
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<IEnumerable<Movie>> GetMoviesByID(int ID);
        Task<int> InsertMovie(Movie movie);
    }
}

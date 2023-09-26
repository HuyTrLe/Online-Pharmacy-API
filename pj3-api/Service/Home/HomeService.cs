using pj3_api.Model;
using pj3_api.Repository.Home;

namespace pj3_api.Service.Home
{
    public class HomeService : IHomeService
    {
        private readonly Lazy<IHomeRepository> _homeRepository;
        public HomeService(IHomeRepository homeRepository) {
            _homeRepository = new Lazy<IHomeRepository>(() => homeRepository);
        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var result = await _homeRepository.Value.GetMovies();
            return result;
        }
        public async Task<IEnumerable<Movie>> GetMoviesById(int ID)
        {
            var result = await _homeRepository.Value.GetMoviesByID(ID);
            return result;
        }
        public async Task<int> InsertMovie(Movie movie)
        {
            var result = await _homeRepository.Value.InsertMovie(movie);
            return result;
        }
    }
}

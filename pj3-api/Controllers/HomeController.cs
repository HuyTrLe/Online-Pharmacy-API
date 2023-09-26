using Microsoft.AspNetCore.Mvc;
using pj3_api.Model;
using pj3_api.Service.Home;

namespace pj3_api.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly Lazy<IHomeService> _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = new Lazy<IHomeService>(() => homeService);
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var result = await _homeService.Value.GetMovies();
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMoviesById(int ID)
        {
            var result = await _homeService.Value.GetMoviesById(ID);
            return result;
        }
        [HttpPost]
        public async Task<int> InsertMovie(Movie movie)
        {
            var result = await _homeService.Value.InsertMovie(movie);
            return result;
        }
    }
}

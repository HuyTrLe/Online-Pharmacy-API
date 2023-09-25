using Microsoft.AspNetCore.Mvc;

namespace pj3_api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

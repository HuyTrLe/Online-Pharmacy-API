using pj3_api.Model;
using pj3_api.Repository.Home;

namespace pj3_api.Service.Admin
{
    public class AdminService : IAdminService
    {
        private readonly Lazy<IHomeRepository> _homeRepository;
        public AdminService(IHomeRepository homeRepository) {
            _homeRepository = new Lazy<IHomeRepository>(() => homeRepository);
        }
       
    }
}

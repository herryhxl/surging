using System.Linq;
using System.Threading.Tasks;
using EFRepository;
using SuperUser.ModelsCustom;
using SuperUser.Service.SuperUser;
using Surging.Core.ProxyGenerator;
using Surging.IModuleServices.User;
using Surging.IModuleServices.Manager.Models;

namespace Surging.Modules.Manager.Domain
{
    public class ManagerService : ProxyServiceBase, IManagerService
    {
        private readonly ISuperUserService _superUserService;
        public ManagerService(ISuperUserService superUserService)
        {
            _superUserService = superUserService;
        }
        public Task<string> SayHello(string name)
        {
            var count = _superUserService.Where().Count();
            return Task.FromResult($"{name} say:hello 数量{count}");
        }
        public Task<SuperUserViewModel> Info(RequestLongModel request)
        {
            return _superUserService.InfoAsync<SuperUserViewModel>(new RequestModel<long> { Id= request.Id });
        }
    }
}

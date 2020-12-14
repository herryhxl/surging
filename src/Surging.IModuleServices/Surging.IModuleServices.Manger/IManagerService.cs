

using EFRepository;
using SuperUser.ModelsCustom;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.CPlatform.Support;
using Surging.Core.CPlatform.Support.Attributes;
using Surging.IModuleServices.Manager.Models;
using System.Threading.Tasks;

namespace Surging.IModuleServices.User
{

    [ServiceBundle("api/{Service}")]
    public interface IManagerService : IServiceKey
    {
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 25000, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;", RequestCacheEnabled = false)]
        Task<string> SayHello(string name);
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 25000, BreakerRequestVolumeThreshold = 3, Injection = @"return 000;", RequestCacheEnabled = false)]
        [HttpPost(true)]
        Task<SuperUserViewModel> Info(RequestLongModel request);
    }
}

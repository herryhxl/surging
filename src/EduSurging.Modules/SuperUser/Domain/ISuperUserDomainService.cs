using SuperUser.Models;
using SuperUser.ModelsCustom;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.CPlatform.Support;
using Surging.Core.CPlatform.Support.Attributes;
using System.Threading.Tasks;

namespace SuperUser.Domain
{
    [ServiceBundle("api/{Service}")]
    public interface ISuperUserDomainService : IServiceKey
    {
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 55000, BreakerRequestVolumeThreshold = 3, Injection = @"return 99;", RequestCacheEnabled = false)]
        [HttpPost(true)]
        Task<SuperUserViewModel> Info(RequestLongModel request);
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 25000, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;", RequestCacheEnabled = false)]
        Task<string> SayHello(string name);
    }
}

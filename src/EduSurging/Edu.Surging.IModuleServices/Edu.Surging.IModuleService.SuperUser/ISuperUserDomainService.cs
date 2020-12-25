using Edu.Surging.Models.Common.Models;
using Edu.Surging.Models.SuperUser.ModelsCustom;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.CPlatform.Support;
using Surging.Core.CPlatform.Support.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Edu.Surging.IModuleService.SuperUser
{
    [ServiceBundle("api/user/{Method}")]
    public interface ISuperUserDomainService : IServiceKey
    {
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 55000, BreakerRequestVolumeThreshold = 30, Injection = @"return 99;", RequestCacheEnabled = false)]
        [HttpPost(true)]
        Task<SuperUserViewModel> Info(RequestLongModel request);
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 55000, MaxConcurrentRequests = 100, BreakerRequestVolumeThreshold = 30, Injection = @"return 1;", RequestCacheEnabled = false)]
        Task<string> SayHello(string name);
        /// <summary>
        /// 验证手机号是否存在
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpPost(true), HttpGet(true)]
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.FairPolling, MaxConcurrentRequests = 100, Injection = @"return true;", RequestCacheEnabled = false)]
        Task<bool> ValidatePhone(string phone);
        /// <summary>
        /// 验证用户名是否已存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.FairPolling, MaxConcurrentRequests = 100, Injection = @"return true;", RequestCacheEnabled = false)]
        [HttpPost(true), HttpGet(true)]
        Task<bool> ValidateAccount(string account);
    }
}

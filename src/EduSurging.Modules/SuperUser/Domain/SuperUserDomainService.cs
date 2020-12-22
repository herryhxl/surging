using EFRepository;
using SuperUser.Models;
using SuperUser.ModelsCustom;
using SuperUser.Service.SuperUser;
using Surging.Core.CPlatform.Exceptions;
using Surging.Core.CPlatform.Transport.Implementation;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperUser.Domain
{
    public class SuperUserDomainService :  ProxyServiceBase, ISuperUserDomainService
    {
        private readonly ISuperUserService _superUserService;
        public SuperUserDomainService(ISuperUserService superUserService)
        {
            _superUserService = superUserService;
        }
        public Task<string> SayHello(string name)
        {
            throw new ValidateException("你错了", 999);
            return Task.FromResult($"你好！{name}");
        }

        public Task<SuperUserViewModel> Info(RequestLongModel request)
        {
            //RpcContext.GetContext().GetContextParameters()
            return _superUserService.InfoAsync<SuperUserViewModel>(new RequestModel<long> { Id = request.Id });
        }
    }
}

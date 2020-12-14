using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperUser.Domain
{
    public class SuperUserDomainService :  ProxyServiceBase, ISuperUserDomainService
    {
        public Task<string> SayHello(string name)
        {
            return Task.FromResult($"你好！{name}");
        }
    }
}

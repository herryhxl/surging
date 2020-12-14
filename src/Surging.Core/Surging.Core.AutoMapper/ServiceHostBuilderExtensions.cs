using Autofac;
using AutoMapper;
using Surging.Core.ServiceHosting.Internal;

namespace Surging.Core.AutoMapper
{
    public static class ServiceHostBuilderExtensions
    {
        public static IServiceHostBuilder UseAutoMapper(this IServiceHostBuilder hostBuilder)
        {
            return hostBuilder.MapServices(mapper =>
            {
                
            });
        }
    }
}

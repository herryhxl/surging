using AutoMapper;
using AutoMapper.Attributes;
using Microsoft.Extensions.Configuration;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Module;
using System.Linq;
using CPlatformAppConfig = Surging.Core.CPlatform.AppConfig;

namespace Surging.Core.AutoMapper
{
    public class AutoMapperModule : EnginePartModule
    {
        private IMapper mapper;
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            var configAssembliesStr = CPlatformAppConfig.GetSection("Automapper:Assemblies").Get<string>();
            if (!string.IsNullOrEmpty(configAssembliesStr))
            {
                AppConfig.AssembliesStrings = configAssembliesStr.Split(";");
            }
            var mapperConfig=AutoMapperBootstrap.Initialize();
            builder.RegisterInstance(mapperConfig).As<IMapper>();
        }
    }
}

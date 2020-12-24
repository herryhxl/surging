using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Edu.Surging.EFServices.SuperUser.ChangeService.SuperUser;
using Edu.Surging.EFServices.SuperUser.Repository.SuperUser;
using Edu.Surging.EFServices.SuperUser.Service.SuperUser;
using Edu.Surging.EFServices.SuperUser.ChangeService.SuperUserInfo;
using Edu.Surging.EFServices.SuperUser.Repository.SuperUserInfo;
using Edu.Surging.EFServices.SuperUser.Service.SuperUserInfo;
using Edu.Surging.EFServices.SuperUser.ChangeService.UserAddress;
using Edu.Surging.EFServices.SuperUser.Repository.UserAddress;
using Edu.Surging.EFServices.SuperUser.Service.UserAddress;
using Autofac;
using System;
using System.Collections.Generic;
using Edu.Surging.EntityFramework;
using Surging.Core.CPlatform;
using Edu.Surging.EFServices.SuperUser.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Edu.Surging.EFServices.SuperUser.Base
{
    public static class SuperUserExtensions
    {
        public static void RegisterSuperUserModuleDbContext(this IServiceCollection services)
        {
            services.AddDbContext<SuperUserDbContext>(optionsBuilder =>
            {
                var dbContextOptionsBuilder = optionsBuilder.UseLazyLoadingProxies();
                //var dataSource = Surging.Core.CPlatform.AppConfig.GetSection("DataSource");
                //var source = dataSource.Get<Dictionary<string, string>>();
                //var connection = source["SuperUserConnection"];
                dbContextOptionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=superuser;user=root;password=password", new MySqlServerVersion(new Version(8, 0, 21)), mig =>//
                {
                    mig.MigrationsAssembly("Edu.Surging.EFServices.SuperUser");
                });
            });
        }
        public static void RegisterSuperUserModuleService(this ContainerBuilder builder)
        {
            builder.RegisterType<WorkContextService>().As<IWorkContext>().InstancePerLifetimeScope();
            builder.RegisterType<SuperUserService>().As<ISuperUserService>().InstancePerLifetimeScope();
            builder.RegisterType<SuperUserChangeService>().As<ISuperUserChangeService>().InstancePerLifetimeScope();
            builder.RegisterType<SuperUserRepository>().As<ISuperUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SuperUserInfoService>().As<ISuperUserInfoService>().InstancePerLifetimeScope();
            builder.RegisterType<SuperUserInfoChangeService>().As<ISuperUserInfoChangeService>().InstancePerLifetimeScope();
            builder.RegisterType<SuperUserInfoRepository>().As<ISuperUserInfoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserAddressService>().As<IUserAddressService>().InstancePerLifetimeScope();
            builder.RegisterType<UserAddressChangeService>().As<IUserAddressChangeService>().InstancePerLifetimeScope();
            builder.RegisterType<UserAddressRepository>().As<IUserAddressRepository>().InstancePerLifetimeScope();
        }
    }
}
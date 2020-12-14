
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SuperUser.ChangeService.SuperUser;
using SuperUser.Repository.SuperUser;
using SuperUser.Service.SuperUser;
using SuperUser.ChangeService.SuperUserInfo;
using SuperUser.Repository.SuperUserInfo;
using SuperUser.Service.SuperUserInfo;
using SuperUser.ChangeService.UserAddress;
using SuperUser.Repository.UserAddress;
using SuperUser.Service.UserAddress;
using Autofac;
using System;
using System.Collections.Generic;
using EFRepository;
using SuperUser.Service;

namespace SuperUser.Base
{
    public static class SuperUserExtensions
    {
        public static void RegisterSuperUserModuleDbContext(this IServiceCollection services)
        {
            services.AddDbContext<SuperUserDbContext>(optionsBuilder =>
            {
                var dbContextOptionsBuilder = optionsBuilder.UseLazyLoadingProxies();
                var dataSource = Surging.Core.CPlatform.AppConfig.GetSection("DataSource");
                var source = dataSource.Get<Dictionary<string, string>>();
                var connection = source["SuperUserConnection"];
                dbContextOptionsBuilder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 21)));
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
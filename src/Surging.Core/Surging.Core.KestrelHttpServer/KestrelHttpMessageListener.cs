﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Engines;
using Surging.Core.CPlatform.Module;
using Surging.Core.CPlatform.Serialization;
using Surging.Core.KestrelHttpServer.Extensions;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Surging.Core.KestrelHttpServer.Filters;
using System.Diagnostics;
using Surging.Core.CPlatform.Configurations;
using Surging.Core.CPlatform.Diagnostics;
using Surging.Core.CPlatform.Serialization.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Surging.Core.KestrelHttpServer
{
    public class KestrelHttpMessageListener : HttpMessageListener, IDisposable
    {
        private readonly ILogger<KestrelHttpMessageListener> _logger;
        private IWebHost _host;
        private bool _isCompleted;
        private readonly ISerializer<string> _serializer;
        private readonly IServiceEngineLifetime _lifetime;
        private readonly IModuleProvider _moduleProvider;
        private readonly CPlatformContainer _container;
        private readonly IServiceRouteProvider _serviceRouteProvider;
        private readonly DiagnosticListener _diagnosticListener;

        public KestrelHttpMessageListener(ILogger<KestrelHttpMessageListener> logger,
            ISerializer<string> serializer,
            IServiceEngineLifetime lifetime,
            IModuleProvider moduleProvider,
            IServiceRouteProvider serviceRouteProvider,
            CPlatformContainer container) : base(logger, serializer, serviceRouteProvider)
        {
            _logger = logger;
            _serializer = serializer;
            _lifetime = lifetime;
            _moduleProvider = moduleProvider;
            _container = container;
            _serviceRouteProvider = serviceRouteProvider;
            _diagnosticListener = new DiagnosticListener(DiagnosticListenerExtensions.DiagnosticListenerName);
        }

        public async Task StartAsync(IPAddress address, int? port)
        {
            try
            {
                if (AppConfig.ServerOptions.DockerDeployMode == DockerDeployMode.Swarm)
                {
                    address = IPAddress.Any;
                }

                var hostBuilder = new WebHostBuilder()
                  .UseContentRoot(Directory.GetCurrentDirectory())
                  .UseKestrel((context, options) =>
                  {
                      options.Limits.MinRequestBodyDataRate = null;
                      options.Limits.MinResponseDataRate = null;
                      options.Limits.MaxRequestBodySize = null;
                      options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
                      if (port != null && port > 0)
                          options.Listen(address, port.Value, listenOptions =>
                          {
                              listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                          });
                      ConfigureHost(context, options, address);

                  })
                  .ConfigureServices(ConfigureServices)
                  .ConfigureLogging((logger) =>
                  {
                      logger.AddConfiguration(
                             CPlatform.AppConfig.GetSection("Logging"));
                  })
                  .Configure(AppResolve);

                if (Directory.Exists(CPlatform.AppConfig.ServerOptions.WebRootPath))
                    hostBuilder = hostBuilder.UseWebRoot(CPlatform.AppConfig.ServerOptions.WebRootPath);
                _host = hostBuilder.Build();
                _lifetime.ServiceEngineStarted.Register(async () =>
                {
                    await _host.RunAsync();
                });

            }
            catch (Exception e)
            {
                _logger.LogError($"http服务主机启动失败，监听地址：{address}:{port}。 ");
            }

        }

        public void ConfigureHost(WebHostBuilderContext context, KestrelServerOptions options, IPAddress ipAddress)
        {
            _moduleProvider.ConfigureHost(new WebHostContext(context, options, ipAddress));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            services.AddMvc(options => { options.EnableEndpointRouting = false; }).AddJsonOptions(options =>
            {
                var dateTimeFromat = "yyyy-MM-dd HH:mm:ss";
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter(dateTimeFromat));
                options.JsonSerializerOptions.Converters.Add(new DateTimeNullJsonConverter(dateTimeFromat));
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                {
                    var setting = new JsonSerializerSettings();
                    setting.DateFormatString = dateTimeFromat;
                    setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    return setting;
                });
            });
            _moduleProvider.ConfigureServices(new ConfigurationContext(services,
                _moduleProvider.Modules,
                _moduleProvider.VirtualPaths,
                AppConfig.Configuration));
            builder.Populate(services);
            builder.Update(_container.Current.ComponentRegistry);
        }

        private void AppResolve(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvc();
            _moduleProvider.Initialize(new ApplicationInitializationContext(app, _moduleProvider.Modules,
                _moduleProvider.VirtualPaths,
                AppConfig.Configuration));
            app.Run(async (context) =>
            {
                var messageId = Guid.NewGuid().ToString("N");
                var sender = new HttpServerMessageSender(_serializer, context, _diagnosticListener);
                try
                {
                    var filters = app.ApplicationServices.GetServices<IAuthorizationFilter>();
                    var isSuccess = await OnAuthorization(context, sender, messageId, filters);
                    if (isSuccess)
                    {
                        var actionFilters = app.ApplicationServices.GetServices<IActionFilter>();
                        await OnReceived(sender, messageId, context, actionFilters);
                    }
                }
                catch (Exception ex)
                {
                    var filters = app.ApplicationServices.GetServices<IExceptionFilter>();
                    WirteDiagnosticError(messageId, ex);
                    await OnException(context, sender, messageId, ex, filters);
                }
            });
        }

        private void WirteDiagnosticError(string messageId, Exception ex)
        {
            _diagnosticListener.WriteTransportError(CPlatform.Diagnostics.TransportType.Rest, new TransportErrorEventData(new DiagnosticMessage
            {
                Id = messageId
            }, ex));
        }

        public void Dispose()
        {
            _host.Dispose();
        }

    }
}

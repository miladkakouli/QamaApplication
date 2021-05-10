using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Qama.Events.Events;
using Qama.Framework.Core.Abstractions.Events;
using Qama.Framework.Core.Abstractions.Persistence;
using Qama.Framework.Core.Abstractions.ServiceLocator;
using Qama.Framework.Core.EventBus.RabbitMQ;
using Qama.Framework.Core.Logging.MicrosoftLogger;
using Qama.Framework.Core.MicrosoftServiceLocator;
using Qama.Framework.Extensions.Microsoft.DependencyInjection;
using Qama.Framework.Extensions.Microsoft.DependencyInjection.MicrosoftSettingProvider;
using Qama.Framework.Extensions.Microsoft.DependencyInjection.RabbitMQ;
using Topshelf;

namespace Qama.TestEventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            Events.Startup.WireUp(services);
            services.AddServiceLocator<MicrosoftServiceLocator>();
            services.AddLogging();

            services.AddRabbitMQEventHandler<TestEvent, Events.EventHandlers.TestEventHandler>();

            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);

            if (environment == "Development")
            {

                builder
                    .AddJsonFile(
                        Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.{environment}.json"),
                        optional: true
                    );
            }
            else
            {
                builder
                    .AddJsonFile($"appsettings.{environment}.json", optional: false);
            }

            var Configuration = builder.Build();

            services.AddMicrosoftSettingProvider<DbConnectionString>("ConnectionStrings", Configuration);
            services.AddMicrosoftSettingProvider<RabbitMQSettings>("RabbitMQSettings", Configuration);

            services.AddLogger<MicrosoftLogger>();
            services.AddSingleton<TestEventWorker>();

            var sp = services.BuildServiceProvider();

            HostFactory.Run(x =>
            {
                x.Service<TestEventWorker>(s =>
                {
                    s.ConstructUsing(sf => sp.GetService<TestEventWorker>());
                    s.WhenStarted(tc =>
                    {
                        tc.Start();
                    });
                    s.WhenStopped(tc =>
                    {
                        tc.Stop();
                        Environment.Exit(0);
                    });
                    s.WhenShutdown(tc =>
                    {
                        tc.Stop();
                        Environment.Exit(0);
                    });

                });
                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.SetDescription("TestEvent");
                x.SetDisplayName("TestEvent");
                x.SetServiceName("TestEvent");

                x.OnException(a =>
                {
                    Console.WriteLine(a.Message);
                });
                x.EnableServiceRecovery(a =>
                {
                    a.RestartService(TimeSpan.FromMinutes(1));
                });
            });
        }
    }
}

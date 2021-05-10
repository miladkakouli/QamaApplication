using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Qama.Events.EventHandlers;
using Qama.Events.Events;
using Qama.Framework.Core.Abstractions.Events;
using Qama.Framework.Core.Abstractions.Persistence;
using Qama.Framework.Core.MicrosoftServiceLocator;
using Qama.Framework.Extensions.Microsoft.DependencyInjection;
using Qama.Framework.Core.Abstractions.Settings;
using Qama.Framework.Core.EventBus.RabbitMQ;
using Qama.Framework.Core.Logging.MicrosoftLogger;
using Qama.Framework.Extensions.Microsoft.DependencyInjection.MicrosoftSettingProvider;

namespace Qama.Presentation
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(services);
            services.AddServiceLocator<MicrosoftServiceLocator>();
            services.AddLogging();
            services.AddMicrosoftSettingProvider<DbConnectionString>("ConnectionStrings", Configuration);
            services.AddMicrosoftSettingProvider<RabbitMQSettings>("RabbitMQSettings", Configuration);

            services.AddLogger<MicrosoftLogger>();

            Commands.Startup.WireUp(services);
            Queries.Startup.WireUp(services);
            Events.Startup.WireUp(services);
            Validators.Startup.WireUp(services);
            Persistence.Startup.WireUp(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllers();
            });
        }
    }
}

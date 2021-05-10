using Microsoft.Extensions.DependencyInjection;
using Qama.Events.EventHandlers;
using Qama.Events.Events;
using Qama.Framework.Core.Abstractions.Events;
using Qama.Framework.Core.Abstractions.Settings;
using Qama.Framework.Core.EventBus.RabbitMQ;
using Qama.Framework.Extensions.Microsoft.DependencyInjection;
using Qama.Framework.Extensions.Microsoft.DependencyInjection.RabbitMQ;

namespace Qama.Events
{
    public static class Startup
    {
        public static void WireUp(this IServiceCollection services)
        {
            services.AddEventBus<RabbitMQEventBus>();
            services.AddRabbitMq<RabbitMQSettings>();
        }
    }
}

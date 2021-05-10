using Microsoft.Extensions.DependencyInjection;
using Qama.Commands.CommandHandlers;
using Qama.Commands.Commands;
using Qama.Framework.Core.CommandBus.InMemory;
using Qama.Framework.Core.EventBus.RabbitMQ;
using Qama.Framework.Extensions.Microsoft.DependencyInjection;

namespace Qama.Commands
{
    public static class Startup
    {
        public static void WireUp(this IServiceCollection services)
        {
            services.AddCommandBus<InMemoryCommandBus>();
            services.AddEventBus<RabbitMQEventBus>();
            services.AddCommandHandlerWithValidationalAndTransactionalDecorator<TestCommand, TestCommandHandler>();
        }
    }
}

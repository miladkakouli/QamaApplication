using Microsoft.Extensions.DependencyInjection;
using Qama.Commands.Commands;
using Qama.Framework.Extensions.Microsoft.DependencyInjection;
using Qama.Queries.Queries;
using Qama.Validators.Validators;

namespace Qama.Validators
{
    public static class Startup
    {
        public static void WireUp(this IServiceCollection services)
        {
            services.AddValidator<TestQuery, TestQueryValidator>();
            services.AddValidator<TestCommand, TestCommandValidator>();
        }
    }
}

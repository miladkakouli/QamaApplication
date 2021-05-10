using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Qama.Framework.Core.Abstractions.Persistence;
using Qama.Framework.Core.QueryBus.InMemory;
using Qama.Framework.Extensions.Microsoft.DependencyInjection;
using Qama.Queries.Queries;
using Qama.Queries.QueryHandlers;

namespace Qama.Queries
{
    public static class Startup
    {
        public static void WireUp(this IServiceCollection services)
        {
            services.AddSingleton<IDbConnection>(x => new SqlConnection(x.GetService<DbConnectionString>().ConnectionString));
            services.AddQueryBus<InMemoryQueryBus>();
            services.AddQueryHandler<TestQuery, TestQueryHandler>();
        }
    }
}

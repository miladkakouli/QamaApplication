using Microsoft.Extensions.DependencyInjection;
using System;
using Qama.Framework.Core.Abstractions.Persistence;
using Qama.Framework.Core.Persistence.NHibernate;
using Qama.Framework.Extensions.Microsoft.DependencyInjection;
using Qama.Framework.Extensions.Microsoft.DependencyInjection.Persistence.NHibernate;
using Qama.Persistence.Entities;
using Qama.Persistence.Repositories;

namespace Qama.Persistence
{
    public static class Startup
    {

        public static void WireUp(this IServiceCollection services)
        {
            services.AddUnitOfWork<NhUnitOfWork>();
            services.AddNHibernatePersistence<DbConnectionString>(typeof(Startup).Assembly);
            services.AddRepository<TestEntity, Guid, TestEntityRepository>();
        }
    }
}

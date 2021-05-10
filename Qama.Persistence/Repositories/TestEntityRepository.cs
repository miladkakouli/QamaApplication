using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Qama.Framework.Core.Abstractions.Events;
using Qama.Framework.Core.Abstractions.Logging;
using Qama.Framework.Core.Abstractions.Persistence;
using Qama.Framework.Core.Persistence.NHibernate;
using Qama.Persistence.Entities;

namespace Qama.Persistence.Repositories
{
    class TestEntityRepository : Repository<TestEntity, Guid>
    {
        public TestEntityRepository(ISession session, IEventBus eventBus, IEverythingLogger everythingLogger)
            : base(session, eventBus, everythingLogger)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qama.Events.Events;
using Qama.Framework.Core.Abstractions.DAL;
using Qama.Framework.Core.Abstractions.Events;

namespace Qama.Persistence.Entities
{
    public class TestEntity : AggregateRoot<Guid>
    {
        protected TestEntity()
        { }
        public TestEntity(string testValue)
        {
            TestValue = testValue;
            this.AddEvent(new TestEvent());
        }
        public string TestValue { get; protected set; }

        public override IList<EventBase> Events { get; protected set; }
    }
}

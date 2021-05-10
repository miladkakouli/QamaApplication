using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qama.Events.Events;
using Qama.Framework.Core.Abstractions.Events;

namespace Qama.Events.EventHandlers
{
    public class TestEventHandler : IEventHandler<TestEvent>
    {
        public TestEventHandler()
        { }
        public Task Handle(TestEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}

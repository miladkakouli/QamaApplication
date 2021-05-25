using System;
using System.Threading.Tasks;
using Qama.Events.Events;
using Qama.Framework.Core.Abstractions.Events;

namespace Qama.TestEventHandler
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

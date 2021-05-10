using Qama.Framework.Core.Abstractions.Logging;

namespace Qama.Events.Events
{
    class TestEventId : LogEventId
    {
        public new static TestEventId DefaultEvent = new TestEventId(0, nameof(DefaultEvent));
        protected TestEventId(int id, string name) : base(id, name)
        { }
    }
}
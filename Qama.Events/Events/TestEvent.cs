using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qama.Framework.Core.Abstractions.Events;

namespace Qama.Events.Events
{
    public class TestEvent : EventBase
    {
        public override string GetRoutingKey()
        {
            return "TestEvent100";
        }
    }
}

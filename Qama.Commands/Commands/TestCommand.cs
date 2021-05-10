using Qama.Framework.Core.Abstractions.Commands;

namespace Qama.Commands.Commands
{
    public class TestCommand : CommandBase
    {
        public string Ssn { get; private set; }
        public TestCommand(string ssn)
        {
            Ssn = ssn;
        }
    }
}

using Qama.Commands.Commands;
using Qama.Framework.Application.Abstractions;

namespace Qama.Presentation.DTOs
{
    public class TestCommandDto : IInputDtoCommand<TestCommand>
    {
        public string Ssn { get; set; }
        public TestCommand ToCommand()
        {
            return new TestCommand(Ssn);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Qama.Commands.Commands;
using Qama.Framework.Application.Abstractions;
using Qama.Framework.Core.Abstractions.Commands;
using Qama.Presentation.DTOs;

namespace Qama.Presentation.Controllers
{
    [Route("[controller]")]

    public class TestCommandController : CommandControllerBase<TestCommand, TestCommandDto>
    {
        public TestCommandController(ICommandBus bus) : base(bus)
        {
        }
    }
}

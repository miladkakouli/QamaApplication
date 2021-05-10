using Microsoft.AspNetCore.Mvc;
using Qama.Framework.Application.Abstractions;
using Qama.Framework.Core.Abstractions.Queries;
using Qama.Presentation.DTOs;
using Qama.Queries.Queries;

namespace Qama.Presentation.Controllers
{
    [Route("[controller]")]
    public class TestQueryController : QueryControllerBase<TestQuery, TestQueryDto>
    {
        public TestQueryController(IQueryBus bus) : base(bus)
        {
        }
    }
}

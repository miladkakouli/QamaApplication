using Qama.Framework.Application.Abstractions;
using Qama.Queries.Queries;

namespace Qama.Presentation.DTOs
{
    public class TestQueryDto : IInputDtoQuery<TestQuery>
    {
        public string Ssn { get; set; }

        public TestQuery ToQuery()
        {
            return new TestQuery(Ssn);
        }
    }
}

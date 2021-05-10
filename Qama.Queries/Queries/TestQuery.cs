using Qama.Framework.Core.Abstractions.Queries;

namespace Qama.Queries.Queries
{
    public class TestQuery : QueryBase
    {
        public string Ssn { get; private set; }
        public TestQuery(string ssn)
        {
            Ssn = ssn;
        }
    }
}

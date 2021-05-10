using System;
using System.Collections.Generic;
using Qama.Framework.Core.Abstractions.Queries;

namespace Qama.Queries.QueryResults
{
    class resultDto
    {
        public string Testvalue { get; set; }
        public Guid Id { get; set; }
    }
    class TestQueryResult : IQueryResult
    {
        public IEnumerable<resultDto> List { get; set; }
    }
}

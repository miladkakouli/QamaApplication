using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Qama.Persistence.Entities;

namespace Qama.Persistence.Mappings
{
    public class TestEntityMapping : ClassMapping<TestEntity>
    {
        public TestEntityMapping()
        {
            //Table("`testentities`");
            Id(a => a.Id, map => map.Generator(Generators.Guid));
            Lazy(false);
            Property(a => a.TestValue);
        }
    }
}

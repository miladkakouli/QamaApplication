using Qama.Framework.Core.Abstractions.Exceptions;

namespace Qama.Validators.Validators
{
    class TestValidationId : ValidationExceptionDomain
    {
        public new static TestValidationId DefaultValidationException = new TestValidationId(0, nameof(DefaultValidationException));
        protected TestValidationId(int id, string name) : base(id, name)
        {
        }
    }
}
using FluentValidation;
using Qama.Framework.Extensions.Validations;
using Qama.Queries.Queries;

namespace Qama.Validators.Validators
{
    public class TestQueryValidator : AbstractValidator<TestQuery>,
        Qama.Framework.Core.Abstractions.Validator.IValidator<TestQuery>
    {
        public TestQueryValidator()
        {
            RuleFor(command => command.Ssn).Must(x => x.IsValidSsn());
        }
        public new void Validate(TestQuery command)
        {
            var r = base.Validate(command);
        }
    }
}

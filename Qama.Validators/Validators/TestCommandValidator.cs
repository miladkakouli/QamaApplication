using FluentValidation;
using Qama.Commands.Commands;
using Qama.Framework.Extensions.Validations;
using ValidationException = Qama.Framework.Core.Abstractions.Exceptions.ValidationException;

namespace Qama.Validators.Validators
{
    public class TestCommandValidator : AbstractValidator<TestCommand>,
        Qama.Framework.Core.Abstractions.Validator.IValidator<TestCommand>
    {
        public TestCommandValidator()
        {
            RuleFor(command => command.Ssn).Must(x => x.IsValidSsn()).WithErrorCode(TestValidationId.DefaultValidationException.ToString());
        }
        public new void Validate(TestCommand command)
        {
            var r = base.Validate(command);
            if (!r.IsValid)
            {
                throw new ValidationException(TestValidationId.DefaultValidationException);
            }
        }
    }
}

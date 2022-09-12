using FluentValidation;

namespace KodlamaioDevs.Application.Features.Developers.Commands.CreateDeveloper
{
    internal class CreateDeveloperCommandValidator : AbstractValidator<CreateDeveloperCommand>
    {
        public CreateDeveloperCommandValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().NotNull();
            RuleFor(e => e.LastName).NotEmpty().NotNull();
            RuleFor(e => e.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(e => e.Password).NotEmpty().NotNull().MinimumLength(9);
        }
    }
}

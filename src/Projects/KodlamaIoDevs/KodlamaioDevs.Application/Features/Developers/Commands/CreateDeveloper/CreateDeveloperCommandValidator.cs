using FluentValidation;

namespace KodlamaioDevs.Application.Features.Developers.Commands.CreateDeveloper
{
    internal class CreateDeveloperCommandValidator : AbstractValidator<CreateDeveloperCommand>
    {
        public CreateDeveloperCommandValidator()
        {
            RuleFor(d => d.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(d => d.Password).NotEmpty().NotNull().MinimumLength(9);
            RuleFor(d => d.FirstName).NotEmpty().NotNull();
            RuleFor(d => d.LastName).NotEmpty().NotNull();
        }
    }
}

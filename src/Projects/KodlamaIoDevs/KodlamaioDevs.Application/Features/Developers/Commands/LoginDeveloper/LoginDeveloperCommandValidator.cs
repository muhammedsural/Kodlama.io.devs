using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace KodlamaioDevs.Application.Features.Developers.Commands.LoginDeveloper
{
    public class LoginDeveloperCommandValidator : AbstractValidator<LoginDeveloperCommand>
    {
        public LoginDeveloperCommandValidator()
        {
            RuleFor(e => e.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(e => e.Password).NotEmpty().NotNull().MinimumLength(9);
        }
    }
}

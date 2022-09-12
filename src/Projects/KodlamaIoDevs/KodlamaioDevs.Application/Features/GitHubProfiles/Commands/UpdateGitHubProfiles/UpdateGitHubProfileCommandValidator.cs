using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfiles
{
    public class UpdateGitHubProfileCommandValidator: AbstractValidator<UpdateGitHubProfileCommand>
    {
        public UpdateGitHubProfileCommandValidator()
        {
            RuleFor(g => g.Id).NotNull();
            RuleFor(g => g.ProfileUrl).NotNull().NotEmpty();
        }
    }
}

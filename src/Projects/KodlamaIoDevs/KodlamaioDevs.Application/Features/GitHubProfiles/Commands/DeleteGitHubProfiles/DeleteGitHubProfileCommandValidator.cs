using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Commands.DeleteGitHubProfiles
{
    public class DeleteGitHubProfileCommandValidator: AbstractValidator<DeleteGitHubProfileCommand>
    {
        public DeleteGitHubProfileCommandValidator()
        {
            RuleFor(g => g.Id).NotNull();
        }
    }
}

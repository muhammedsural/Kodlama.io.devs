using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Commands.CreateGitHubProfiles
{
    public class CreateGitHubProfileCommandValidator : AbstractValidator<CreateGitHubProfileCommand>
    {
        public CreateGitHubProfileCommandValidator()
        {
            RuleFor(g => g.DeveloperId).NotNull();
            RuleFor(g => g.ProfileUrl).NotEmpty().NotNull();
        }
    }
}

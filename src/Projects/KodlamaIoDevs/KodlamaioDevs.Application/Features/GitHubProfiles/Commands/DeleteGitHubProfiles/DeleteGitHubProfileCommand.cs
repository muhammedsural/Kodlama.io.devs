using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KodlamaioDevs.Application.Features.GitHubProfiles.Dtos;
using KodlamaioDevs.Application.Features.GitHubProfiles.Rules;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Constants;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Commands.DeleteGitHubProfiles
{
    public class DeleteGitHubProfileCommand : IRequest<DeleteGitHubProfileDto>
    {
        public int Id { get; set; }

        public class DeleteGitHubProfileCommandHandler : IRequestHandler<DeleteGitHubProfileCommand,DeleteGitHubProfileDto>

        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public DeleteGitHubProfileCommandHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<DeleteGitHubProfileDto> Handle(DeleteGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                GitHubProfile mappedGitHubProfile = _mapper.Map<GitHubProfile>(request);
                GitHubProfile gitHubProfile = await _gitHubProfileRepository.DeleteAsync(mappedGitHubProfile);
                DeleteGitHubProfileDto deleteGitHubProfileDto = _mapper.Map<DeleteGitHubProfileDto>(gitHubProfile);
                //deleteGitHubProfileDto.Message =  OperationClaims.ProgrammingLanguageDeleted;

                return deleteGitHubProfileDto;
            }
        }
    }
}

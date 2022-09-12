using AutoMapper;
using KodlamaioDevs.Application.Features.GitHubProfiles.Dtos;
using KodlamaioDevs.Application.Features.GitHubProfiles.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Commands.CreateGitHubProfiles
{
    public class CreateGitHubProfileCommand : IRequest<CreateGitHubProfileDto>
    {
        public int DeveloperId { get; set; }
        public string ProfileUrl { get; set; }

        public class CreateGithubProfileCommandHandler : IRequestHandler<CreateGitHubProfileCommand,CreateGitHubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public CreateGithubProfileCommandHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<CreateGitHubProfileDto> Handle(CreateGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                GitHubProfile mappedGitHubProfile = _mapper.Map<GitHubProfile>(request);
                await _githubProfileBusinessRules.GitHubProfileCanNotBeDuplicatedWhenInserted(request.DeveloperId);
                GitHubProfile createdGitHubProfile = await _gitHubProfileRepository.AddAsync(mappedGitHubProfile);
                CreateGitHubProfileDto createGitHubProfileDto = _mapper.Map<CreateGitHubProfileDto>(createdGitHubProfile);
                return createGitHubProfileDto;

            }
        }
    }
}

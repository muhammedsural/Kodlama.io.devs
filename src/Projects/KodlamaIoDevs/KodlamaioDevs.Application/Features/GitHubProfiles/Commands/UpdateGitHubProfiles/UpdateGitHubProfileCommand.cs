using AutoMapper;
using KodlamaioDevs.Application.Features.GitHubProfiles.Dtos;
using KodlamaioDevs.Application.Features.GitHubProfiles.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfiles
{
    public class UpdateGitHubProfileCommand : IRequest<UpdateGitHubProfileDto>
    {
        public int Id { get; set; }
        public string ProfileUrl { get; set; }

        public class UpdateGitHubProfileCommandHandler : IRequestHandler<UpdateGitHubProfileCommand,UpdateGitHubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public UpdateGitHubProfileCommandHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<UpdateGitHubProfileDto> Handle(UpdateGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                GitHubProfile mappedGitHubProfile = _mapper.Map<GitHubProfile>(request);
                await _githubProfileBusinessRules.GitHubProfileCanNotBeDuplicatedWhenInserted(request.Id);

                GitHubProfile gitHubProfile = await _gitHubProfileRepository.UpdateAsync(mappedGitHubProfile);
                UpdateGitHubProfileDto updateGitHubProfileDto = _mapper.Map<UpdateGitHubProfileDto>(gitHubProfile);

                return updateGitHubProfileDto;
            }
        }
    }
}

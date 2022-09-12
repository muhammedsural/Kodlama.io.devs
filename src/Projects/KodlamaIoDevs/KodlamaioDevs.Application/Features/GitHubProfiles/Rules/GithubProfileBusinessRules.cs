using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Rules
{
    public class GithubProfileBusinessRules
    {
        private readonly IGitHubProfileRepository _gitHubProfileRepository;

        public GithubProfileBusinessRules(IGitHubProfileRepository gitHubProfileRepository)
            => _gitHubProfileRepository = gitHubProfileRepository;

        public async Task GitHubProfileCanNotBeDuplicatedWhenInserted(int userId)
        {
            GitHubProfile result = await _gitHubProfileRepository.GetAsync(b => b.DeveloperId == userId);
            if (result != null) throw new BusinessException("There is already a GitHub profile assigned");
        }
    
        public void GitHubProfileShouldExistWhenUpdated(GitHubProfile gitHubProfile)
        {
            if (gitHubProfile == null) throw new BusinessException("Requested GitHub profile does not exist");
        }
    
        public void GitHubProfileShouldExistWhenDeleted(GitHubProfile gitHubProfile)
        {
            if (gitHubProfile == null) throw new BusinessException("Requested GitHub profile does not exist");
        }
    }
}

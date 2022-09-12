using Core.Persistence.Repositories;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using Persistence.Contexts;

namespace KodlamaioDevs.Persistence.Repositories
{
    public class GitHubProfileRepository : EfRepositoryBase<GitHubProfile, BaseDbContext>,IGitHubProfileRepository
    {
        public GitHubProfileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

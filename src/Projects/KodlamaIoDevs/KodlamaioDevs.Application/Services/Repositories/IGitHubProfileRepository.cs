using Core.Persistence.Repositories;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Services.Repositories
{
    public interface IGitHubProfileRepository : IAsyncRepository<GitHubProfile>,IRepository<GitHubProfile>
    {
    }
}

using Core.Persistence.Repositories;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using Persistence.Contexts;

namespace KodlamaioDevs.Persistence.Repositories
{
    public class DeveloperRepository: EfRepositoryBase<Developer, BaseDbContext>, IDeveloperRepository
    {
        public DeveloperRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using Persistence.Contexts;

namespace KodlamaioDevs.Persistence.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology,BaseDbContext>,ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

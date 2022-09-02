using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Persistence.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(BaseDbContext context) : base(context)
        {
            
        }
    }
}

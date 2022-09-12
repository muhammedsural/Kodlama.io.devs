using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Services.Repositories
{
    public interface ITechnologyRepository : IAsyncRepository<Technology>,IRepository<Technology>
    {
    }
}

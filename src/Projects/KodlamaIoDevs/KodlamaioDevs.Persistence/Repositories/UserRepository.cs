using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using KodlamaioDevs.Application.Services.Repositories;
using Persistence.Contexts;

namespace KodlamaioDevs.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User,BaseDbContext>,IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

using KodlamaioDevs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using KodlamaioDevs.Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(@"Server=DESKTOP-R8212T7;Database=KodlamaioDevsDb;Trusted_Connection=True;"));
            //services.AddDbContext<BaseDbContext>(options =>options.UseSqlServer(configuration.GetConnectionString("KodlamaIoDevsConnectionString")));

            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IGitHubProfileRepository, GitHubProfileRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

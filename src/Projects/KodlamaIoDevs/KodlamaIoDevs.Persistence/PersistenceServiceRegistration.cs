using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            //services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(@"Server=DESKTOP-8212T7;Database=KodlamaIoDevsDb;UID=msural;PWD=sural6177;"));
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("KodlamaIoDevsConnectionString")));



            return services;
        }
    }
}

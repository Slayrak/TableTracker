using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TableTracker.Infrastructure;

namespace TableTracker.ServiceConfigurations
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TableDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TableTracker")));

            services.AddDbContext<IdentityTableDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityTableTracker")));

            return services;
        }
    }
}

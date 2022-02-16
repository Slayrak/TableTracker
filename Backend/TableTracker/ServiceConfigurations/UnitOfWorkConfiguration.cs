using System;

using Microsoft.Extensions.DependencyInjection;

using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;
using TableTracker.Infrastructure;
using TableTracker.Infrastructure.Repositories;

namespace TableTracker.ServiceConfigurations
{
    public static class UnitOfWorkConfiguration
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork<Guid>, UnitOfWork<Guid>>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<TableDbContext>();
                var unitOfWork = new UnitOfWork<Guid>(context);
                unitOfWork.RegisterRepositories(typeof(IRepository<,>).Assembly, typeof(Repository<,>).Assembly);
                return unitOfWork;
            });
        }
    }
}

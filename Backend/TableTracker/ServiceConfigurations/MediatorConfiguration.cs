using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace TableTracker.ServiceConfigurations
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            return services.AddMediatR();
        }
    }
}

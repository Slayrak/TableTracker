using System.Reflection;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using TableTracker.Application;

namespace TableTracker.ServiceConfigurations
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(CommandResponse<object>).Assembly);
        }
    }
}

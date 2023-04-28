using MediatR;

using Microsoft.Extensions.DependencyInjection;

using TableTracker.Application.CQRS;

namespace TableTracker.ServiceConfigurations;

public static class MediatorConfiguration
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        return services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CommandResponse<object>).Assembly));
    }
}

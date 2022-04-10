using System.Text.Json.Serialization;

using Microsoft.Extensions.DependencyInjection;

namespace TableTracker.ServiceConfigurations
{
    public static class ControllerConfiguration
    {
        public static IServiceCollection AddApiControllers(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            return services;
        }
    }
}

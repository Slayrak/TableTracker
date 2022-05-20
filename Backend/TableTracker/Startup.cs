using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TableTracker.Domain.Interfaces;
using TableTracker.Infrastructure;
using TableTracker.ServiceConfigurations;

namespace TableTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagger();
            services.AddMapper();
            services.AddDataAccess(Configuration);
            services.AddMediator();
            services.AddValidaton();
            services.AddCustomAuthorization(Configuration);
            services.AddApiControllers();

            services.AddScoped<IEmailHandler, EmailHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TableTracker v1"));
            }

            app.UseStaticFiles();
            app.UseCustomMiddlewares();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCrossOriginResourceSharing();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

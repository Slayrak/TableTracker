using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;

using TableTracker.Infrastructure;
using TableTracker.Infrastructure.Identity;
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TableTracker", Version = "v1" });
            });

            services.AddMapper();
            services.AddDbContexts(Configuration);
            services.AddUnitOfWork();
            services.AddMediator();

            services.AddIdentity<TableTrackerIdentityUser, TableTrackerIdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<IdentityTableDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<TableTrackerIdentityUser, TableTrackerIdentityRole, IdentityTableDbContext, Guid>>()
                .AddRoleStore<RoleStore<TableTrackerIdentityRole, IdentityTableDbContext, Guid>>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TableTracker v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCrossOriginResourceSharing();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

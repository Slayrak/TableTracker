using System;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using TableTracker.Infrastructure;
using TableTracker.Infrastructure.Identity;

namespace TableTracker.ServiceConfigurations
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddIdentity<TableTrackerIdentityUser, TableTrackerIdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<IdentityTableDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<TableTrackerIdentityUser, TableTrackerIdentityRole, IdentityTableDbContext, Guid>>()
                .AddRoleStore<RoleStore<TableTrackerIdentityRole, IdentityTableDbContext, Guid>>();

            return services;
        }
    }
}

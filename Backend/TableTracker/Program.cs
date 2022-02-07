using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;

using TableTracker.Infrastructure;

namespace TableTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            Migrate(host.Services);
            host.Run();
        }

        public static void Migrate(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<TableDbContext>();

            //var seed = new DataSeed(dbContext);
            //seed.SeedData();

            dbContext.Database.Migrate();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

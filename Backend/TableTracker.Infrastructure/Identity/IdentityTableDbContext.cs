using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Infrastructure.Identity;

namespace TableTracker.Infrastructure
{
    public class IdentityTableDbContext : IdentityDbContext<TableTrackerIdentityUser, TableTrackerIdentityRole, Guid>
    {
        public IdentityTableDbContext(DbContextOptions options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TableTrackerIdentityUser>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            });

            builder.Entity<TableTrackerIdentityRole>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            });
        }

    }
}

using Microsoft.EntityFrameworkCore;

using TableTracker.Domain.Entities;

namespace TableTracker.Infrastructure
{
    public class TableDbContext : DbContext
    {
        public TableDbContext(DbContextOptions opts)
            : base(opts)
        {
        }

        public DbSet<Franchise> Franchises { get; set; }

        public DbSet<Layout> Layouts { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantVisitor> RestaurantVisitors { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<VisitorFavourites> VisitorFavouritess { get; set; }

        public DbSet<VisitorHistory> VisitorHistorys { get; set; }

        public DbSet<Waiter> Waiters { get; set; }
    }
}

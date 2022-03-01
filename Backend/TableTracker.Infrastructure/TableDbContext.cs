using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;

namespace TableTracker.Infrastructure
{
    public class TableDbContext : DbContext
    {
        public TableDbContext(DbContextOptions<TableDbContext> opts)
            : base(opts)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Franchise> Franchises { get; set; }

        public DbSet<Layout> Layouts { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantVisitor> RestaurantVisitors { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<VisitorFavourites> VisitorFavourites { get; set; }

        public DbSet<VisitorHistory> VisitorHistorys { get; set; }

        public DbSet<Waiter> Waiters { get; set; }

        public DbSet<Cuisine> Cuisines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasOne(x => x.Franchise)
                .WithMany(x => x.Restaurants)
                .HasForeignKey(x => x.FranchiseId);

            modelBuilder.Entity<Restaurant>()
                .HasOne(x => x.Layout)
                .WithOne(x => x.Restaurant)
                .HasForeignKey<Layout>(x => x.RestaurantId);

            modelBuilder.Entity<Restaurant>()
                .HasOne(x => x.Manager)
                .WithOne(x => x.Restaurant)
                .HasForeignKey<Manager>(x => x.RestaurantId);

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.Table)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.TableId);

            modelBuilder.Entity<Table>()
                .HasOne(x => x.Waiter)
                .WithMany(x => x.Tables)
                .HasForeignKey(x => x.WaiterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Waiter>()
                .HasMany(x => x.Tables)
                .WithOne(x => x.Waiter)
                .OnDelete(DeleteBehavior.Restrict);

            #region Cuisine

            modelBuilder.Entity<Cuisine>()
                .HasIndex(x => x.CuisineEnum)
                .IsUnique();

            modelBuilder.Entity<Cuisine>()
                .Property(x => x.CuisineEnum)
                .IsRequired();

            #endregion

            #region Franchise

            modelBuilder.Entity<Franchise>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Franchise>()
                .Property(x => x.Name)
                .IsRequired();

            #endregion

            //#region User

            //modelBuilder.Entity<User>()
            //    .Property(x => x.Email)
            //    .IsRequired();

            //modelBuilder.Entity<User>()
            //    .HasIndex(x => x.Email)
            //    .IsUnique();

            //#endregion

            //why waiter need a key on visitor

            //modelBuilder.Entity<Restaurant>()
            //    .HasMany(x => x.Cuisines)
            //    .WithMany(x => x.Restaurants)
            //    .UsingEntity<Restaurant>();

        }
    }
}

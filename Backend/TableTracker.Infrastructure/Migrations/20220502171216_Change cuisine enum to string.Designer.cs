﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TableTracker.Infrastructure;

namespace TableTracker.Infrastructure.Migrations
{
    [DbContext(typeof(TableDbContext))]
    [Migration("20220502171216_Change cuisine enum to string")]
    partial class Changecuisineenumtostring
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CuisineRestaurant", b =>
                {
                    b.Property<long>("CuisinesId")
                        .HasColumnType("bigint");

                    b.Property<long>("RestaurantsId")
                        .HasColumnType("bigint");

                    b.HasKey("CuisinesId", "RestaurantsId");

                    b.HasIndex("RestaurantsId");

                    b.ToTable("CuisineRestaurant");
                });

            modelBuilder.Entity("ReservationVisitor", b =>
                {
                    b.Property<long>("ReservationsId")
                        .HasColumnType("bigint");

                    b.Property<long>("VisitorsId")
                        .HasColumnType("bigint");

                    b.HasKey("ReservationsId", "VisitorsId");

                    b.HasIndex("VisitorsId");

                    b.ToTable("ReservationVisitor");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Cuisine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CuisineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CuisineName")
                        .IsUnique();

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Franchise", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Franchises");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Layout", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("LayoutData")
                        .HasColumnType("tinyint");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId")
                        .IsUnique();

                    b.ToTable("Layouts");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Manager", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerState")
                        .HasColumnType("int");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("TableId")
                        .HasColumnType("bigint");

                    b.Property<long?>("WaiterId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.HasIndex("WaiterId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Restaurant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CoordX")
                        .HasColumnType("float");

                    b.Property<double>("CoordY")
                        .HasColumnType("float");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<long>("FranchiseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("LayoutId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ManagerId")
                        .HasColumnType("bigint");

                    b.Property<int>("NumberOfTables")
                        .HasColumnType("int");

                    b.Property<string>("PriceRange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.RestaurantVisitor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AverageMoneySpent")
                        .HasColumnType("float");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<float>("RestaurantRate")
                        .HasColumnType("real");

                    b.Property<int>("TimesVisited")
                        .HasColumnType("int");

                    b.Property<long>("VisitorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("VisitorId");

                    b.ToTable("RestaurantVisitors");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Table", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CoordX")
                        .HasColumnType("float");

                    b.Property<double>("CoordY")
                        .HasColumnType("float");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<double>("TableSize")
                        .HasColumnType("float");

                    b.Property<long?>("WaiterId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("WaiterId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Visitor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("GeneralTrustFactor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.VisitorFavourite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<long>("VisitorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("VisitorId");

                    b.ToTable("VisitorFavourites");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.VisitorHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<long>("VisitorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("VisitorId");

                    b.ToTable("VisitorHistorys");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Waiter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfServingTables")
                        .HasColumnType("int");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<int>("WaiterState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Waiters");
                });

            modelBuilder.Entity("CuisineRestaurant", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Cuisine", null)
                        .WithMany()
                        .HasForeignKey("CuisinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTracker.Domain.Entities.Restaurant", null)
                        .WithMany()
                        .HasForeignKey("RestaurantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReservationVisitor", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTracker.Domain.Entities.Visitor", null)
                        .WithMany()
                        .HasForeignKey("VisitorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Layout", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Restaurant", "Restaurant")
                        .WithOne("Layout")
                        .HasForeignKey("TableTracker.Domain.Entities.Layout", "RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Manager", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Restaurant", "Restaurant")
                        .WithOne("Manager")
                        .HasForeignKey("TableTracker.Domain.Entities.Manager", "RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTracker.Domain.Entities.Waiter", null)
                        .WithMany("Reservations")
                        .HasForeignKey("WaiterId");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Restaurant", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Franchise", "Franchise")
                        .WithMany("Restaurants")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.RestaurantVisitor", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTracker.Domain.Entities.Visitor", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Table", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTracker.Domain.Entities.Waiter", "Waiter")
                        .WithMany("Tables")
                        .HasForeignKey("WaiterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Restaurant");

                    b.Navigation("Waiter");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.VisitorFavourite", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTracker.Domain.Entities.Visitor", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.VisitorHistory", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableTracker.Domain.Entities.Visitor", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Waiter", b =>
                {
                    b.HasOne("TableTracker.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Waiters")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Franchise", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Restaurant", b =>
                {
                    b.Navigation("Layout");

                    b.Navigation("Manager");

                    b.Navigation("Tables");

                    b.Navigation("Waiters");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Table", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("TableTracker.Domain.Entities.Waiter", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}

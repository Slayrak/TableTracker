using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;

namespace TableTracker.Infrastructure
{
    public class DataSeed
    {
        public static void SeedData(TableDbContext context)
        {
            if(!context.Cuisines.Any())
            {
                var cuisines = new List<Cuisines>();

                for (int i = 0; i < 10; i++)
                {
                    cuisines.Add(new Cuisines { Cuisine = Cuisine.International, Id = i + 1 });
                }

                context.AddRange(cuisines);
                context.SaveChanges();
            }

            if(!context.Franchises.Any())
            {
                var franchises = new List<Franchise>();

                for (int i = 0; i < 10; i++)
                {
                    franchises.Add(new Franchise { Id = i + 1, Name = $"{i + 1} franchise" });
                }

                context.AddRange(franchises);
                context.SaveChanges();
            }

            if(!context.Restaurants.Any())
            {
                var restaurants = new List<Restaurant>();

                for (int i = 0; i < 10; i++)
                {
                    restaurants.Add(new Restaurant
                    {
                        CoordX = i + 1,
                        CoordY = i,
                        Discount = Discount.NoDiscount,
                        FranchiseId = i + 1,
                        Id = i + 1,
                        NumberOfTables = 10 + i,
                        PriceRange = "$$",
                        Rating = 5,
                        Type = RestaurantType.Cafe,
                        
                    });
                }

                context.AddRange(restaurants);
                context.SaveChanges();

            }

            if(!context.Managers.Any())
            {
                var managers = new List<Manager>();

                for (int i = 0; i < 10; i++)
                {
                    managers.Add(new Manager
                    {
                        RestaurantId = i + 1,
                        ManagerState = ManagerState.Unocupied,
                        Avatar = "RandomStr",
                        Email = $"exampleEmail{i+1}@service.domain",
                        FullName = $"Generic Boy {i + 1}",
                        Id = i + 1,
                    });

                    Restaurant rest = context.Restaurants.Find(i + 1);
                    rest.Manager = managers[-1];
                    rest.ManagerId = managers[-1].Id;

                    context.Restaurants.Update(rest);

                }

                context.AddRange(managers);
                context.SaveChanges();

            }

            if(!context.Layouts.Any())
            {
                var layouts = new List<Layout>();

                for (int i = 0; i < 10; i++)
                {
                    layouts.Add(new Layout { Id = i + 1, LayoutData = 0, RestaurantId = i + 1 });

                    Restaurant rest = context.Restaurants.Find(i + 1);
                    rest.Layout = layouts[-1];
                    rest.LayoutId = layouts[-1].Id;

                    context.Restaurants.Update(rest);
                }

                context.AddRange(layouts);
                context.SaveChanges();
            }

            if(!context.Visitors.Any())
            {
                var visitors = new List<Visitor>();

                for (int i = 0; i < 10; i++)
                {
                    visitors.Add(new Visitor
                    {
                        Avatar = "Random string",
                        Email = $"MehBruh{i + 1}@service.domain",
                        FullName = $"Juan{i + 1}",
                        GeneralTrustFactor = 2,
                        Id = i + 1,
                    });
                }

                context.AddRange(visitors);
                context.SaveChanges();
            }

            if(!context.Waiters.Any())
            {
                var waiters = new List<Waiter>();

                for (int i = 0; i < 10; i++)
                {
                    waiters.Add(new Waiter
                    {
                        FullName = $"DefaultChad{i + 1}",
                        NumberOfServingTables = i + 1,
                        WaiterState = WaiterState.Unoccupied,
                        Avatar = "Random str",
                        Email = $"WaiterClone{i + 1}@idk.com",
                        Id = i + 1,
                        RestaurantId = i + 1,
                    });
                }

                context.AddRange(waiters);
                context.SaveChanges();
            }

            if(!context.Tables.Any())
            {
                var tables = new List<Table>();

                for (int i = 0; i < 10; i++)
                {
                    tables.Add(new Table
                    {
                        CoordX = i + 1,
                        CoordY = i,
                        Floor = i + 1,
                        State = TableState.Unoccupied,
                        NumberOfSeats = 4,
                        TableSize = 10,
                        Id = i + 1,
                        Number = 1,
                        RestaurantId = i + 1,
                        WaiterId = i + 1,
                    });
                }

                context.AddRange(tables);
                context.SaveChanges();

            }

            if(!context.Reservations.Any())
            {
                var reservations = new List<Reservation>();

                for (int i = 0; i < 10; i++)
                {
                    reservations.Add(new Reservation
                    {
                        Date = DateTime.Now,
                        Id = i + 1,
                        TableId = i + 1,
                    });
                }

                context.AddRange(reservations);
                context.SaveChanges();
            }

            if(!context.RestaurantVisitors.Any())
            {
                var restVisitor = new List<RestaurantVisitor>();

                for (int i = 0; i < 10; i++)
                {
                    restVisitor.Add(new RestaurantVisitor
                    {
                        RestaurantId = i + 1,
                        AverageMoneySpent = 10,
                        Id = i + 1,
                        RestaurantRate = 5,
                        TimesVisited = i + 1,
                        VisitorId = i + 1,
                    });
                }

                context.AddRange(restVisitor);
                context.SaveChanges();
            }

            if(!context.VisitorFavourites.Any())
            {
                var favourites = new List<VisitorFavourites>();

                for (int i = 0; i < 10; i++)
                {
                    favourites.Add(new VisitorFavourites { Id = i + 1, RestaurantId = i + 1, VisitorId = i + 1 });
                }

                context.AddRange(favourites);
                context.SaveChanges();
            }

            if(!context.VisitorHistorys.Any())
            {
                var history = new List<VisitorHistory>();

                for (int i = 0; i < 10; i++)
                {
                    history.Add(new VisitorHistory
                    {
                        DateTime = DateTime.Now,
                        Id = i + 1,
                        RestaurantId = i + 1,
                        VisitorId = i + 1,
                    });
                }

                context.AddRange(history);
                context.SaveChanges();
            }
        }
    }
}

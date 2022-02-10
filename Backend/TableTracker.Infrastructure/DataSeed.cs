using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;
using TableTracker.Infrastructure.Identity;

namespace TableTracker.Infrastructure
{
    public class DataSeed
    {
        private readonly UserManager<TableTrackerIdentityUser> _userManager;
        private readonly RoleManager<TableTrackerIdentityRole> _roleManager;

        public DataSeed(UserManager<TableTrackerIdentityUser> userManger, RoleManager<TableTrackerIdentityRole> roleManager)
        {
            _userManager = userManger;
            _roleManager = roleManager;
        }

        public async Task SeedData(TableDbContext context, IdentityTableDbContext identityContext)
        {
            #region Roles
            string[] roleNames = { "Admin", "Developer", "Manager", "Waiter", "Vistor", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    roleResult = await _roleManager.CreateAsync(new TableTrackerIdentityRole() { Name = roleName });
                }
            }
            #endregion

            #region IdentityUsers
            if (!identityContext.TableTrackerIdentityUsers.Any())
            {

                for (int i = 0; i < 30; i++)
                {
                    TableTrackerIdentityUser userToAdd = new TableTrackerIdentityUser();

                    if (i < 10)
                    {
                        userToAdd = new TableTrackerIdentityUser
                        {
                            UserName = $"Generic Boy {i + 1}",
                            Email = $"exampleEmail{i + 1}@service.domain",
                        };

                        var result = await _userManager.CreateAsync(userToAdd, "Secret123$");

                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(userToAdd, Enum.GetName(typeof(UserRole), UserRole.Manager));
                        }
                    }
                    else if (i < 20)
                    {
                        userToAdd = new TableTrackerIdentityUser
                        {
                            UserName = $"Juan{i + 1}",
                            Email = $"MehBruh{i + 1}@service.domain",
                        };
                        var result = await _userManager.CreateAsync(userToAdd, "Secret123$");

                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(userToAdd, Enum.GetName(typeof(UserRole), UserRole.Visitor));
                        }
                    }
                    else if(i < 30)
                    {
                        userToAdd = new TableTrackerIdentityUser
                        {
                            UserName = $"DefaultChad{i + 1}",
                            Email = $"WaiterClone{i + 1}@idk.com",
                        };
                        var result = await _userManager.CreateAsync(userToAdd, "Secret123$");

                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(userToAdd, Enum.GetName(typeof(UserRole), UserRole.Waiter));
                        }
                    }
                }
            }
            #endregion


            #region Cuisine

            if (!context.Cuisines.Any())
            {
                var cuisines = new List<Cuisines>();

                for (int i = 0; i < 10; i++)
                {
                    cuisines.Add(new Cuisines { Cuisine = Cuisine.International, Id = i + 1 });
                }

                await context.AddRangeAsync(cuisines);
                await context.SaveChangesAsync();
            }

            #endregion

            #region Frachise

            if (!context.Franchises.Any())
            {
                var franchises = new List<Franchise>();

                for (int i = 0; i < 10; i++)
                {
                    franchises.Add(new Franchise { Id = i + 1, Name = $"{i + 1} franchise" });
                }

                await context.AddRangeAsync(franchises);
                await context.SaveChangesAsync();
            }

            #endregion

            #region Restaurant

            if (!context.Restaurants.Any())
            {
                var restaurants = new List<Restaurant>();

                List<Cuisines> cuisines = context.Cuisines.ToList();

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
                        Cuisines = cuisines,
                    });
                }

                await context.AddRangeAsync(restaurants);
                await context.SaveChangesAsync();

            }

            #endregion

            #region Manager

            if (!context.Managers.Any())
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
                    rest.ManagerId = managers[-1].Id;

                    context.Restaurants.Update(rest);

                }

                await context.AddRangeAsync(managers);
                await context.SaveChangesAsync();

            }

            #endregion

            #region Layout

            if (!context.Layouts.Any())
            {
                var layouts = new List<Layout>();

                for (int i = 0; i < 10; i++)
                {
                    layouts.Add(new Layout { Id = i + 1, LayoutData = 0, RestaurantId = i + 1 });

                    Restaurant rest = context.Restaurants.Find(i + 1);
                    rest.LayoutId = layouts[-1].Id;

                    context.Restaurants.Update(rest);
                }

                await context.AddRangeAsync(layouts);
                await context.SaveChangesAsync();
            }

            #endregion;

            #region Visitor

            if (!context.Visitors.Any())
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

                await context.AddRangeAsync(visitors);
                await context.SaveChangesAsync();
            }

            #endregion

            #region Waiter

            if (!context.Waiters.Any())
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

                await context.AddRangeAsync(waiters);
                await context.SaveChangesAsync();
            }

            #endregion

            #region Table

            if (!context.Tables.Any())
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

                await context.AddRangeAsync(tables);
                await context.SaveChangesAsync();
            }

            #endregion

            #region Reservation

            if (!context.Reservations.Any())
            {
                var reservations = new List<Reservation>();

                List<Visitor> visitors = context.Visitors.ToList();

                for (int i = 0; i < 10; i++)
                {
                    reservations.Add(new Reservation
                    {
                        Date = DateTime.Now,
                        Id = i + 1,
                        TableId = i + 1,
                        Visitors = visitors,
                    });
                }

                await context.AddRangeAsync(reservations);
                await context.SaveChangesAsync();
            }

            #endregion

            #region RestaurantVisitor

            if (!context.RestaurantVisitors.Any())
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

                await context.AddRangeAsync(restVisitor);
                await context.SaveChangesAsync();
            }

            #endregion

            #region VisitorFavourites

            if (!context.VisitorFavourites.Any())
            {
                var favourites = new List<VisitorFavourites>();

                for (int i = 0; i < 10; i++)
                {
                    favourites.Add(new VisitorFavourites { Id = i + 1, RestaurantId = i + 1, VisitorId = i + 1 });
                }

                await context.AddRangeAsync(favourites);
                await context.SaveChangesAsync();
            }

            #endregion

            #region VisitorHistory

            if (!context.VisitorHistorys.Any())
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

               await context.AddRangeAsync(history);
               await context.SaveChangesAsync();
            }

            #endregion
        }
    }
}

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
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
            string[] roleNames = { "Admin", "Developer", "Manager", "Waiter", "Visitor", "User" };
            IdentityResult roleResult;

            var restaurants = new List<Restaurant>();
            var tableTrackerIdentityUsers = new List<TableTrackerIdentityUser>();
            var cuisines = new List<Cuisine>();
            var franchises = new List<Franchise>();
            var managers = new List<Manager>();
            var layouts = new List<Layout>();
            var visitors = new List<Visitor>();
            var waiters = new List<Waiter>();
            var tables = new List<Table>();
            var reservations = new List<Reservation>();
            var restVisitor = new List<RestaurantVisitor>();
            var favourites = new List<VisitorFavourite>();
            var history = new List<VisitorHistory>();

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

                        tableTrackerIdentityUsers.Add(userToAdd);

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

                        tableTrackerIdentityUsers.Add(userToAdd);


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

                        tableTrackerIdentityUsers.Add(userToAdd);


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
                foreach (int entity in Enum.GetValues(typeof(CuisineName)))
                {
                    cuisines.Add(new Cuisine { CuisineEnum = (CuisineName)entity});
                }

                await context.AddRangeAsync(cuisines);
            }

            #endregion

            #region Frachise

            if (!context.Franchises.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    franchises.Add(new Franchise { Name = $"{i + 1} franchise" });
                }

                await context.AddRangeAsync(franchises);
            }

            #endregion

            #region Restaurant

            if (!context.Restaurants.Any())
            {

                for (int i = 0; i < 10; i++)
                {
                    restaurants.Add(new Restaurant
                    {
                        CoordX = i + 1,
                        CoordY = i,
                        Discount = Discount.NoDiscount,
                        Franchise = franchises[i],
                        NumberOfTables = 10 + i,
                        PriceRange = "$$",
                        Rating = 5,
                        Type = RestaurantType.Cafe,
                        Cuisines = cuisines,
                    });
                }

                await context.AddRangeAsync(restaurants);

            }

            #endregion

            #region Manager

            if (!context.Managers.Any())
            {

                //TODO: Define Rest find 

                for (int i = 0; i < 10; i++)
                {
                    managers.Add(new Manager
                    {
                        Restaurant = restaurants[i],
                        ManagerState = ManagerState.Unocupied,
                        Avatar = "RandomStr",
                        Email = $"exampleEmail{i+1}@service.domain",
                        FullName = $"Generic Boy {i + 1}",
                    });

                    //Restaurant rest = context.Restaurants.Find(restaurants[i].Id);
                    restaurants[i].Manager = managers[^1];

                }

                await context.AddRangeAsync(managers);

            }

            #endregion

            #region Layout

            if (!context.Layouts.Any())
            {
                //TODO: Define Rest find

                for (int i = 0; i < 10; i++)
                {
                    layouts.Add(new Layout { LayoutData = 0, Restaurant = restaurants[i] });

                    //Restaurant rest = context.Restaurants.Find((long) i + 1);
                    restaurants[i].Layout = layouts[^1];

                    //context.Restaurants.Update(restaurants[i]);
                }

                await context.AddRangeAsync(layouts);
            }

            #endregion;

            #region Visitor

            if (!context.Visitors.Any())
            {
                //TODO link IdentityUsers

                for (int i = 0; i < 10; i++)
                {
                    visitors.Add(new Visitor
                    {
                        Avatar = "Random string",
                        Email = $"MehBruh{i + 1}@service.domain",
                        FullName = $"Juan{i + 1}",
                        GeneralTrustFactor = 2,
                    });
                }

                await context.AddRangeAsync(visitors);
            }

            #endregion

            #region Waiter

            if (!context.Waiters.Any())
            {
                //TODO: link IdentityUsers

                for (int i = 0; i < 10; i++)
                {
                    waiters.Add(new Waiter
                    {
                        FullName = $"DefaultChad{i + 1}",
                        NumberOfServingTables = i + 1,
                        WaiterState = WaiterState.Unoccupied,
                        Avatar = "Random str",
                        Email = $"WaiterClone{i + 1}@idk.com",
                        Restaurant = restaurants[i],
                    });
                }

                await context.AddRangeAsync(waiters);
            }

            #endregion

            #region Table

            if (!context.Tables.Any())
            {

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
                        Number = 1,
                        Restaurant = restaurants[i],
                        Waiter = waiters[i],
                    });
                }

                await context.AddRangeAsync(tables);
            }

            #endregion

            #region Reservation

            if (!context.Reservations.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    reservations.Add(new Reservation
                    {
                        Date = DateTime.Now,
                        Table = tables[i],
                        Visitors = visitors,
                    });
                }

                await context.AddRangeAsync(reservations);
            }

            #endregion

            #region RestaurantVisitor

            if (!context.RestaurantVisitors.Any())
            {

                for (int i = 0; i < 10; i++)
                {
                    restVisitor.Add(new RestaurantVisitor
                    {
                        Restaurant = restaurants[i],
                        AverageMoneySpent = 10,
                        RestaurantRate = 5,
                        TimesVisited = i + 1,
                        Visitor = visitors[i],
                    });
                }

                await context.AddRangeAsync(restVisitor);
            }

            #endregion

            #region VisitorFavourites

            if (!context.VisitorFavourites.Any())
            {

                for (int i = 0; i < 10; i++)
                {
                    favourites.Add(new VisitorFavourite { Restaurant = restaurants[i], Visitor = visitors[i] });
                }

                await context.AddRangeAsync(favourites);
            }

            #endregion

            #region VisitorHistory

            if (!context.VisitorHistorys.Any())
            {

                for (int i = 0; i < 10; i++)
                {
                    history.Add(new VisitorHistory
                    {
                        DateTime = DateTime.Now,
                        Restaurant = restaurants[i],
                        Visitor = visitors[i],
                    });
                }

               await context.AddRangeAsync(history);
            }

            #endregion

            await context.SaveChangesAsync();

            await identityContext.SaveChangesAsync();
        }

    }
}

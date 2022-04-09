using System;

using TableTracker.Infrastructure.Repositories;
using TableTracker.Domain.Interfaces.Repositories;

using Xunit;

namespace TableTracker.Tests.UnitOfWork
{
    public class UnitOfWorkTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly UnitOfWorkFixture unitOfWorkFixture;

        public UnitOfWorkTests(UnitOfWorkFixture fixture)
        {
            unitOfWorkFixture = fixture;
        }

        [Fact]
        public void GenerateRepositories_Generates()
        {
            var repo1 = unitOfWorkFixture.UnitOfWork.GetRepository<IFranchiseRepository>();
            var repo2 = unitOfWorkFixture.UnitOfWork.GetRepository<ILayoutRepository>();
            var repo3 = unitOfWorkFixture.UnitOfWork.GetRepository<IManagerRepository>();
            var repo4 = unitOfWorkFixture.UnitOfWork.GetRepository<IReservationRepository>();
            var repo5 = unitOfWorkFixture.UnitOfWork.GetRepository<IRestaurantRepository>();
            var repo6 = unitOfWorkFixture.UnitOfWork.GetRepository<IRestaurantVisitorRepository>();
            var repo7 = unitOfWorkFixture.UnitOfWork.GetRepository<ITableRepository>();
            var repo8 = unitOfWorkFixture.UnitOfWork.GetRepository<IUserRepository>();
            var repo9 = unitOfWorkFixture.UnitOfWork.GetRepository<IVisitorFavouriteRepository>();
            var repo10 = unitOfWorkFixture.UnitOfWork.GetRepository<IVisitorHistoryRepository>();
            var repo11 = unitOfWorkFixture.UnitOfWork.GetRepository<IVisitorRepository>();
            var repo12 = unitOfWorkFixture.UnitOfWork.GetRepository<IWaiterRepository>();

            Assert.IsType<FranchiseRepository>(repo1);
            Assert.IsType<LayoutRepository>(repo2);
            Assert.IsType<ManagerRepository>(repo3);
            Assert.IsType<ReservationRepository>(repo4);
            Assert.IsType<RestaurantRepository>(repo5);
            Assert.IsType<RestaurantVisitorRepository>(repo6);
            Assert.IsType<TableRepository>(repo7);
            Assert.IsType<UserRepository>(repo8);
            Assert.IsType<VisitorFavouriteRepository>(repo9);
            Assert.IsType<VisitorHistoryRepository>(repo10);
            Assert.IsType<VisitorRepository>(repo11);
            Assert.IsType<WaiterRepository>(repo12);
        }

        [Fact]
        public void GetRepository_IncorrectParameter_ThrowsNotSupportedException()
        {
            Assert.Throws<NotSupportedException>(unitOfWorkFixture.UnitOfWork.GetRepository<string>);
            Assert.Throws<NotSupportedException>(unitOfWorkFixture.UnitOfWork.GetRepository<FranchiseRepository>);
        }
    }
}
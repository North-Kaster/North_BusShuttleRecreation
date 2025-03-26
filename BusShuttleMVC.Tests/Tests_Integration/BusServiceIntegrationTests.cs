using Microsoft.EntityFrameworkCore;
using BusShuttleMVC.Data;
using BusShuttleMVC.Services;
using DomainModel;

namespace BusShuttleMVC.Tests.Services
{
    [TestClass]
    public class BusServiceIntegrationTests
    {
        private ApplicationDbContext _inMemoryContext = null!;
        private BusService _busService = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            // Use in-memory database for integration tests
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BusServiceTestDB")
                .Options;

            // Create a new context with the in-memory database
            _inMemoryContext = new ApplicationDbContext(options);
            _inMemoryContext.Buses.AddRange(new List<Bus>
                {
                    new(Guid.NewGuid(), 1),
                    new(Guid.NewGuid(), 2),
                    new(Guid.NewGuid(), 3)
                });
            _inMemoryContext.SaveChanges();

            // Initialize the service with the in-memory context
            _busService = new BusService(_inMemoryContext);
        }

        [TestMethod]
        public void Test_BusService_Integration()
        {
            // Test GetAllBuses. Should initially have 3 buses
            var getAllBusesResult = _busService.GetAllBuses();
            Assert.AreEqual(3, getAllBusesResult.Count);

            // Add a new bus
            var newBus = new Bus(Guid.NewGuid(), 123);
            _busService.AddBus(newBus);

            // Test GetAllBuses. Should now have 4 buses
            getAllBusesResult = _busService.GetAllBuses();
            Assert.AreEqual(4, getAllBusesResult.Count);

            // Find the newly added bus
            var findBusResult = _busService.FindBusByID(newBus.Id);
            Assert.AreEqual(findBusResult, newBus);

            // Delete the newly added bus
            _busService.DeleteBus(newBus);
            Assert.IsNull(_busService.FindBusByID(newBus.Id));

            // Test GetAllBuses. Should now have 3 buses again
            getAllBusesResult = _busService.GetAllBuses();
            Assert.AreEqual(3, getAllBusesResult.Count);
        }
    }
}



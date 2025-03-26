using Microsoft.EntityFrameworkCore;
using BusShuttleMVC.Data;
using BusShuttleMVC.Services;
using DomainModel;

namespace BusShuttleMVC.Tests.Services
{
    [TestClass]
    public class BusServiceIntegrationTests
    {
        [TestMethod]
        public void Test_BusService_Integration()
        {
         // Use in-memory database for integration tests
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "BusServiceTestDB")
        .Options;

            // Create a new context with the in-memory database
            using (var inMemoryContext = new ApplicationDbContext(options))
            {
                inMemoryContext.Buses.AddRange(new List<Bus>
                {
                    new(Guid.NewGuid(), 1),
                    new(Guid.NewGuid(), 2),
                    new(Guid.NewGuid(), 3)
                });
                inMemoryContext.SaveChanges();

                // Initialize the service with the in-memory context
                var busService = new BusService(inMemoryContext);

                // Test GetAllBuses. Should initially have 3 buses
                var getAllBusesResult = busService.GetAllBuses();
                Assert.AreEqual(3, getAllBusesResult.Count);

                // Add a new bus
                var newBus = new Bus(Guid.NewGuid(), 123);
                busService.AddBus(newBus);

                // Test GetAllBuses. Should now have 4 buses
                getAllBusesResult = busService.GetAllBuses();
                Assert.AreEqual(4, getAllBusesResult.Count);

                // Find the newly added bus
                var findBusResult = busService.FindBusByID(newBus.Id);
                Assert.AreEqual(findBusResult, newBus);

                // Delete the newly added bus
                busService.DeleteBus(newBus);
                Assert.IsNull(busService.FindBusByID(newBus.Id));

                // Test GetAllBuses. Should now have 3 buses again
                getAllBusesResult = busService.GetAllBuses();
                Assert.AreEqual(3, getAllBusesResult.Count);

            }   
        }
    }

}
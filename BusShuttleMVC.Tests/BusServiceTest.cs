using Moq;
using Microsoft.EntityFrameworkCore;
using BusShuttleMVC.Data;
using BusShuttleMVC.Services;
using DomainModel;

namespace BusShuttleMVC.Tests.Services
{
    [TestClass]
    public class BusServiceTest
    {
        private Mock<ApplicationDbContext> _mockContext = new();
        private Mock<DbSet<Bus>> _mockDbSet = new();
        private BusService _busService = null!;

        [TestInitialize]
        public void BusServiceTestInitialization()
        {
            _mockContext.Setup(m => m.Buses).Returns(_mockDbSet.Object);
            _busService = new BusService(_mockContext.Object);
        }

        [TestMethod]
        public void Test_GetAllBuses_ShouldReturnAllBuses()
        {
            var busData = new List<Bus>
            {
                new(Guid.NewGuid(), 1),
                new(Guid.NewGuid(), 2),
                new(Guid.NewGuid(), 3)
            }.AsQueryable();

            // Mocking IQueryable interface
            var mockBusDbSet = new Mock<DbSet<Bus>>();
            mockBusDbSet.As<IQueryable<Bus>>().Setup(m => m.Provider).Returns(busData.Provider);
            mockBusDbSet.As<IQueryable<Bus>>().Setup(m => m.Expression).Returns(busData.Expression);
            mockBusDbSet.As<IQueryable<Bus>>().Setup(m => m.ElementType).Returns(busData.ElementType);
            mockBusDbSet.As<IQueryable<Bus>>().Setup(m => m.GetEnumerator()).Returns(busData.GetEnumerator());

            _mockContext.Setup(c => c.Buses).Returns(mockBusDbSet.Object);

            var result = _busService.GetAllBuses();
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void Test_FindBusByID_returns_correct_bus()
        {
            var busGuidToFind = Guid.NewGuid();
            var bus = new Bus(busGuidToFind, 123);
            _mockDbSet.Setup(m => m.Find(bus.Id)).Returns(bus);

            var result = _busService.FindBusByID(bus.Id);
            
            Assert.AreEqual(bus, result);
        }

        [TestMethod]
        public void Test_AddBus_adds_to_context()
        {
            
            _busService.AddBus(new Bus(Guid.NewGuid(), 123));

            _mockDbSet.Verify(m => m.Add(It.IsAny<Bus>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        
        [TestMethod]
        public void Test_DeleteBus_deletes_from_context()
        {
            var _busService = new BusService(_mockContext.Object);
            var bus = new Bus(Guid.NewGuid(), 123);

            _busService.DeleteBus(bus);

            _mockDbSet.Verify(m => m.Remove(It.IsAny<Bus>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

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
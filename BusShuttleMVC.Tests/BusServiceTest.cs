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
        [TestMethod]
        

        public void Test_AddBus_adds_to_context()
        {
            var mockSet = new Mock<DbSet<Bus>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Buses).Returns(mockSet.Object);

            var service = new BusService(mockContext.Object);
            service.AddBus(new Bus(Guid.NewGuid(), 123));

            mockSet.Verify(m => m.Add(It.IsAny<Bus>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());                 
        }

        public void Test_DeleteBus_deletes_from_context()
        {
            var mockSet = new Mock<DbSet<Bus>>();
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Buses).Returns(mockSet.Object);

            var service = new BusService(mockContext.Object);
            var bus = new Bus(Guid.NewGuid(), 123);
            service.AddBus(bus);
            service.DeleteBus(bus);

            mockSet.Verify(m => m.Remove(It.IsAny<Bus>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
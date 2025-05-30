using DomainModel;
using BusShuttleMVC.Data;

namespace BusShuttleMVC.Services
{
    public class BusService : IBusService
    {
        private readonly ApplicationDbContext _context;
        public BusService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Bus> GetAllBuses()
        {
            return _context.Buses.ToList();
        }
        public Bus? FindBusByID(Guid id)
        {
            return _context.Buses.Find(id);
        }
        public void CreateBus(Bus bus)
        {
            _context.Buses.Add(bus);
            _context.SaveChanges();
        }

        public void DeleteBus(Bus bus)
        {
            _context.Buses.Remove(bus);
            _context.SaveChanges();
        }
    }
}
using DomainModel;
using BusShuttleMVC.Data;

namespace BusShuttleMVC.Services
{
    public class BusStopService : IBusStopService
    {
        private readonly ApplicationDbContext _context;

        public BusStopService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BusStop> GetAllBusStops()
        {
            return _context.BusStops.ToList();
        }

        public BusStop? FindBusStopByID(Guid id)
        {
            return _context.BusStops.Find(id);
        }

        public void CreateBusStop(BusStop busStop)
        {
            _context.BusStops.Add(busStop);
            _context.SaveChanges();
        }

        public void DeleteBusStop(BusStop busStop)
        {
            _context.BusStops.Remove(busStop);
            _context.SaveChanges();
        }
    }
}
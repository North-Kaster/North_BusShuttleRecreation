using DomainModel;
using BusShuttleMVC.Data;

namespace BusShuttleMVC.Services
{
    public class BusLoopService : IBusLoopService
    {
        private readonly ApplicationDbContext _context;

        public BusLoopService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BusLoop> GetAllBusLoops()
        {
            return _context.BusLoops.ToList();
        }

        public BusLoop? FindBusLoopByID(Guid id)
        {
            return _context.BusLoops.Find(id);
        }

        public void AddBusLoop(BusLoop busLoop)
        {
            _context.BusLoops.Add(busLoop);
            _context.SaveChanges();
        }

        public void DeleteBusLoop(BusLoop busLoop)
        {
            _context.BusLoops.Remove(busLoop);
            _context.SaveChanges();
        }
    }
}
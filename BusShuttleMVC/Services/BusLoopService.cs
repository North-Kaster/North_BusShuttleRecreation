using DomainModel;
using BusShuttleMVC.Data;
using Microsoft.EntityFrameworkCore;


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
            return _context.BusLoops
                   .Include(bl => bl.LoopBusRoute)
                   .FirstOrDefault(bl => bl.Id == id);
        }

        public void CreateBusLoop(BusLoop busLoop)
        {
            _context.BusLoops.Add(busLoop);
            _context.SaveChanges();
        }

        public void DeleteBusLoop(BusLoop busLoop)
        {
            _context.BusLoops.Remove(busLoop);
            _context.SaveChanges();
        }
         public void AssignRouteToLoop(Guid busLoopId, Guid busRouteId)
        {
            var busLoop = FindBusLoopByID(busLoopId);
            if (busLoop != null)
            {
                busLoop.BusRouteId = busRouteId;
                _context.SaveChanges();
            }
        }
    }
}
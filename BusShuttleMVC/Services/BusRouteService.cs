using DomainModel;
using BusShuttleMVC.Data;

namespace BusShuttleMVC.Services
{
    public class BusRouteService : IBusRouteService
    {
        private readonly ApplicationDbContext _context;

        public BusRouteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<BusRoute> GetAllBusRoutes()
        {
            return _context.BusRoutes.ToList();
        }

        public BusRoute? FindBusRouteByID(Guid id)
        {
            return _context.BusRoutes.Find(id);
        }
        public void AddBusRoute(BusRoute busRoute)
        {
            _context.BusRoutes.Add(busRoute);
            _context.SaveChanges();
        }
        public void DeleteBusRoute(BusRoute busRoute)
        {
            _context.BusRoutes.Remove(busRoute);
            _context.SaveChanges();
        }
        public void UpdateBusRoute(BusRoute busRoute)
        {
            _context.BusRoutes.Update(busRoute);
            _context.SaveChanges();
        }
        public void AddStopToRoute(BusRoute busRoute, BusStop busStop)
        {
            var routeStop = new RouteStop
            {
                BusRouteId = busRoute.Id,
                BusStopId = busStop.Id
            };

            busRoute.RouteStops.Add(routeStop);
            _context.SaveChanges();
        }
    }
}
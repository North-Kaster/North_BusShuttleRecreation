using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class BusRouteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BusRouteViewModel()
        {
            BusLoops = new List<BusLoopViewModel>();
            BusStops = new List<BusStopViewModel>();
            BusRoutes = new List<BusRouteViewModel>();
        }

        public IEnumerable<BusLoopViewModel> BusLoops { get; set; }
        public IEnumerable<BusStopViewModel> BusStops { get; set; }
        public IEnumerable<BusRouteViewModel> BusRoutes { get; set; } 

        public static BusRouteViewModel FromBusRoute(BusRoute busRoute)
        {
            return new BusRouteViewModel
            {
                Id = busRoute.Id,
                Name = busRoute.Name
            };
        }
    }
}
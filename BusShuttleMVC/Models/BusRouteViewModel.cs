using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class BusRouteViewModel
    {
        public BusRouteViewModel()
        {
            BusLoops = new List<BusLoopViewModel>();
            BusStops = new List<BusStopViewModel>();
        }

        public IEnumerable<BusLoopViewModel> BusLoops { get; set; }
        public IEnumerable<BusStopViewModel> BusStops { get; set; }
    }
}
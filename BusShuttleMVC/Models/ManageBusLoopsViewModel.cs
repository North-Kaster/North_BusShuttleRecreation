using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class ManageBusLoopsViewModel
    {
        public IEnumerable<BusLoopViewModel> BusLoops { get; set; }
        public IEnumerable<BusRouteViewModel> BusRoutes { get; set; }
    }
}
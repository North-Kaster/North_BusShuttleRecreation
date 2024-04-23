using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class EntryViewModel
    {
        public Guid BusLoopId { get; set; }
        public string BusNumber { get; set; }
        public Guid BusStopId { get; set; }
        public int Boarded { get; set; }
        public int LeftBehind { get; set; }

        public IEnumerable<BusLoopViewModel> BusLoops { get; set; }
        public IEnumerable<BusViewModel> Buses { get; set; }
        public IEnumerable<BusStopViewModel> BusStops { get; set; }

        public EntryViewModel()
        {
            BusLoops = new List<BusLoopViewModel>();
            Buses = new List<BusViewModel>();
            BusStops = new List<BusStopViewModel>();
        }
    }
}
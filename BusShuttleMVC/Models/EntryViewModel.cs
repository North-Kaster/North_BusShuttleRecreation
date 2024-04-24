using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class EntryViewModel
    {
        public int Boarded { get; set; }
        public int LeftBehind { get; set; }
        public string BusStopName { get; set; }
        public DateTime Timestamp { get; set; }
        public string BusLoopName { get; set; }
        public string Driver { get; set; }
        public string BusNumber { get; set; }
        

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
using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class ManagerDashboardViewModel
    {
        public IEnumerable<EntryViewModel> Entries { get; set; }
        public IEnumerable<BusViewModel> Buses { get; set; }

        public ManagerDashboardViewModel()
        {
            Buses = new List<BusViewModel>();
            Entries = new List<EntryViewModel>();
        }
    }
}
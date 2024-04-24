using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class ManageEntryViewModel
    {
        public IEnumerable<EntryViewModel> Entries { get; set; }

        public ManageEntryViewModel()
        {
            Entries = new List<EntryViewModel>();
        }
    }
}
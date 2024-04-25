using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class ManageDriversViewModel
    {
        public string UserName { get; set; }
        public string IsActivated { get; set; }
    }
}

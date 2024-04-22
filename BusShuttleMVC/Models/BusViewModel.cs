using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class BusViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public int BusNumber { get; set; }

        public static BusViewModel FromBus(Bus bus)
        {   
            return new BusViewModel
            {
                Id = bus.Id,
                BusNumber = bus.BusNumber
            };
        }
    }
}
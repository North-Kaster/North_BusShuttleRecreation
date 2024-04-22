using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class BusStopViewModel
    {
        public Guid Id { get; set; }
        [Required]
        // Disable warning for uninitialized Name, since 
        // Name will always be initialized on creation
        #pragma warning disable CS8618 
        public string Name { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }

        public static BusStopViewModel FromBusStop(BusStop busStop)
        {
            return new BusStopViewModel
            {
                Id = busStop.Id,
                Name = busStop.Name,
                Latitude = busStop.Latitude,
                Longitude = busStop.Longitude
            };
        }
    }
}
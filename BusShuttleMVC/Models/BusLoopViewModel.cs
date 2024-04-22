using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace BusShuttleMVC.Models
{
    public class BusLoopViewModel
    {
        public Guid Id { get; set; }
        [Required]
        // Disable warning for uninitialized Name, since 
        // Name will always be initialized on creation
        #pragma warning disable CS8618
        public string Name { get; set; }

        public static BusLoopViewModel FromBusLoop(BusLoop busLoop)
        {
            return new BusLoopViewModel
            {
                Id = busLoop.Id,
                Name = busLoop.Name
            };
        }
    }
}
using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class BusRoute
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 

        // Collection navigation property for the join table
        public ICollection<RouteStop> RouteStops { get; set; }

        public BusRoute() 
        {
            RouteStops = new List<RouteStop>();
        }

        public BusRoute(Guid id, string name)
        {
            Id = id;
            Name = name;
            RouteStops = new List<RouteStop>();
        }
    }
}
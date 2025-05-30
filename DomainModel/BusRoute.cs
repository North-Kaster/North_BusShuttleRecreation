using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class BusRoute
    {
        public Guid Id { get; set; }

        // Collection navigation property for the join table
        public ICollection<RouteStop> RouteStops { get; set; }

        public BusRoute() 
        {
            RouteStops = new List<RouteStop>();
        }

        public BusRoute(Guid id)
        {
            Id = id;
            RouteStops = new List<RouteStop>();
        }
    }
}
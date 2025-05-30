using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class BusStop 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Collection navigation property for the join table
        public ICollection<RouteStop> RouteStops { get; set; }

        public BusStop() 
        {
            RouteStops = new List<RouteStop>();
        }

        public BusStop(Guid id, string name, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            RouteStops = new List<RouteStop>();
        }
    }
}
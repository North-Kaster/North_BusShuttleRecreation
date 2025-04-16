using DomainModel;
using System;

public class RouteStop
{
    public Guid Id { get; set; }
    public Guid BusRouteId { get; set; }
    public BusRoute BusRoute { get; set; }

    public Guid BusStopId { get; set; }
    public BusStop BusStop { get; set; }

    public int Order { get; set; } // To keep track of the order of stops in a route

    public RouteStop()
    {
    }
    public RouteStop(Guid id, Guid busRouteId, Guid busStopId, int order)
    {
        Id = id;
        BusRouteId = busRouteId;
        BusStopId = busStopId;
        Order = order;
    }
}
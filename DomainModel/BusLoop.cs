namespace DomainModel;

public class BusLoop 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BusRouteId { get; set; }
    public BusRoute LoopBusRoute { get; set; }
    public BusLoop()
    {
    }

    public BusLoop (Guid id, string name, BusRoute busRoute)
    {
        Id = id;
        Name = name;
        LoopBusRoute = busRoute;
    }
}
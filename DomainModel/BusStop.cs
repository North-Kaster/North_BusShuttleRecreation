namespace DomainModel;

public class BusStop 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public BusStop(Guid id, string name, double latitude, double longitude)
    {
        Id = id;
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }
}
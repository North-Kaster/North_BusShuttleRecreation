namespace DomainModel;

public class Stop 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Latitude { get; set; }
    public int Longitude { get; set; }

    public Stop(int id, string name, int latitude, int longitude)
    {
        Id = id;
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }
}
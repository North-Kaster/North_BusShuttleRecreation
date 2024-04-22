namespace DomainModel;

public class BusLoop 
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public BusLoop (Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
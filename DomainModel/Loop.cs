namespace DomainModel;

public class Loop 
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Loop (int id, string name)
    {
        Id = id;
        Name = name;
    }
}
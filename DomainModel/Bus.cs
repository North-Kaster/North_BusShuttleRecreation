namespace DomainModel;

public class Bus
{
    public Guid Id { get; set; }
    public int BusNumber { get; set; }

    public Bus(Guid id, int busNumber)
    {
        Id = id;
        BusNumber = busNumber;
    }
    public void Update(int busNumber)
    {
        BusNumber = busNumber;
    }
}
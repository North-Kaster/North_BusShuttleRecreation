namespace DomainModel;

public class Bus
{
    public int Id { get; set; }
    public int BusNumber { get; set; }

    public static List<Bus> Buses = new List<Bus>();

    public static void AddBus(int busNumber)
    {
        Buses.Add(new Bus { BusNumber = busNumber });
    }
}
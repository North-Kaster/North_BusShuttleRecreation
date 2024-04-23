namespace DomainModel;

public class Entry 
{
    public Guid Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int Boarded { get; set; }
    public int LeftBehind { get; set; }

    public Guid BusLoopId { get; set; }
    public BusLoop BusLoop { get; set; }
    public string BusNumber { get; set; }
    public Guid BusStopId { get; set; }
    public BusStop BusStop { get; set; }

    public Entry() { }
    public Entry(Guid id, Guid busLoopId, string busNumber, Guid busStopId, int boarded, int leftBehind, DateTime timeStamp)
    {
        Id = id;
        BusLoopId = busLoopId;
        BusNumber = busNumber;
        BusStopId = busStopId;
        Boarded = boarded;
        LeftBehind = leftBehind;
        Timestamp = timeStamp;
    }
}
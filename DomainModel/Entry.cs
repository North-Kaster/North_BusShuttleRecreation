namespace DomainModel;

public class Entry 
{
    public Guid Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int Boarded { get; set; }
    public int LeftBehind { get; set; }
    public string Driver { get; set;}

    public Guid BusLoopId { get; set; }
    public string BusNumber { get; set; }
    public Guid BusStopId { get; set; }


    public Entry() { }
    public Entry(Guid id, DateTime timeStamp, int boarded, int leftBehind, string driver, Guid busLoopId, string busNumber, Guid busStopId)
    {
        Id = id;
        Timestamp = timeStamp;
        Boarded = boarded;
        LeftBehind = leftBehind;
        Driver = driver;
        BusLoopId = busLoopId;
        BusNumber = busNumber;
        BusStopId = busStopId;
    }
}
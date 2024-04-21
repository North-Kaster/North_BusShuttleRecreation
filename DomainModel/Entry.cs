namespace DomainModel;

public class Entry 
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int Boarded { get; set; }
    public int LeftBehind { get; set; }

    public Entry(int id, DateTime timestamp, int boarded, int leftBehind)
    {
        Id = id;
        Timestamp = timestamp;
        Boarded = boarded;
        LeftBehind = leftBehind;
    }
}
using DomainModel;
namespace BusShuttleMVC.Services
{
    public interface IEntryService
    {
        List<Entry> GetEntries();
        Task<Entry> CreateEntry(Guid id, DateTime timeStamp, int boarded, int leftBehind, string driver, Guid busLoopId, string busNumber, Guid busStopId);
    }
}

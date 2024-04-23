using DomainModel;
namespace BusShuttleMVC.Services
{
    public interface IEntryService
    {
        Task<Entry> CreateEntry(Guid busLoopId, string busNumber, Guid busStopId, int boarded, int leftBehind);
    }
}

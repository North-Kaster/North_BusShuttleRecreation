using DomainModel;
using BusShuttleMVC.Data;

namespace BusShuttleMVC.Services
{
    public class EntryService : IEntryService
{
    private readonly ApplicationDbContext _context;

    public EntryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Entry> CreateEntry(Guid id, DateTime timeStamp, int boarded, int leftBehind, string driver, Guid busLoopId, string busNumber, Guid busStopId)
    {
        var entry = new Entry(Guid.NewGuid(), DateTime.Now, boarded, leftBehind, driver, busLoopId, busNumber, busStopId);
        _context.Entries.Add(entry);
        await _context.SaveChangesAsync();

        return entry;
    }
}
}

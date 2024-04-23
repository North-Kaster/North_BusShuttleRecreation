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

    public async Task<Entry> CreateEntry(Guid busLoopId, string busNumber, Guid busStopId, int boarded, int leftBehind)
    {
        var entry = new Entry(Guid.NewGuid(), busLoopId, busNumber, busStopId, boarded, leftBehind, DateTime.Now);

        _context.Entries.Add(entry);
        await _context.SaveChangesAsync();

        return entry;
    }
}
}

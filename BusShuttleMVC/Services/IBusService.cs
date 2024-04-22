using DomainModel;
namespace BusShuttleMVC.Services
{
    public interface IBusService
    {
        List<Bus> GetAllBuses();
        Bus? FindBusByID(Guid id);
        void UpdateBusByID(int id, int busNumber);
        void AddBus(Bus bus);
        void DeleteBus(Bus bus);
    }
}
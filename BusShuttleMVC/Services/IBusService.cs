using DomainModel;
namespace BusShuttleMVC.Services
{
    public interface IBusService
    {
        List<Bus> GetAllBuses();
        Bus? FindBusByID(int id);
        void UpdateBusByID(int id, int busNumber);
        void AddBus(Bus bus);
    }
}
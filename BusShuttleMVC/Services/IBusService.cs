using DomainModel;
namespace BusShuttleMVC.Services

{
    public interface IBusService
    {
        List<Bus> GetAllBuses();
        Bus? FindBusByID(Guid id);
        void AddBus(Bus bus);
        void DeleteBus(Bus bus);
    }
}
using DomainModel;
namespace BusShuttleMVC.Services

{
    public interface IBusService
    {
        List<Bus> GetAllBuses();
        Bus? FindBusByID(Guid id);
        void CreateBus(Bus bus);
        void DeleteBus(Bus bus);
    }
}
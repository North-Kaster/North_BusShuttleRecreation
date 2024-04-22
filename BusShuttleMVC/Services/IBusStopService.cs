using DomainModel;
namespace BusShuttleMVC.Services

{
    public interface IBusStopService
    {
        List<BusStop> GetAllBusStops();
        BusStop? FindBusStopByID(Guid id);
        void AddBusStop(BusStop busStop);
        void DeleteBusStop(BusStop busStop);
    }
}
using DomainModel;
namespace BusShuttleMVC.Services

{
    public interface IBusRouteService
    {
        List<BusRoute> GetAllBusRoutes();
        BusRoute? FindBusRouteByID(Guid id);
        void AddBusRoute(BusRoute busRoute);
        void DeleteBusRoute(BusRoute busRoute);
        void UpdateBusRoute(BusRoute busRoute);
        void AddStopToRoute(BusRoute busRoute, BusStop busStop);
    }
}
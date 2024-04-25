using DomainModel;
namespace BusShuttleMVC.Services

{
    public interface IBusLoopService
    {
        List<BusLoop> GetAllBusLoops();
        BusLoop? FindBusLoopByID(Guid id);
        void AddBusLoop(BusLoop busLoop);
        void DeleteBusLoop(BusLoop busLoop);
        void AddBusRouteToLoop(Guid busLoopId, BusRoute busRoute);
        BusLoop FindBusLoopByNameWithStops(string loopName);
    }
}
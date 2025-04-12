using DomainModel;
namespace BusShuttleMVC.Services

{
    public interface IBusLoopService
    {
        List<BusLoop> GetAllBusLoops();
        BusLoop? FindBusLoopByID(Guid id);
        void CreateBusLoop(BusLoop busLoop);
        void DeleteBusLoop(BusLoop busLoop);
        void AssignRouteToLoop(Guid busLoopId, BusRoute busRoute);
        BusLoop FindBusLoopByNameWithStops(string loopName);
    }
}
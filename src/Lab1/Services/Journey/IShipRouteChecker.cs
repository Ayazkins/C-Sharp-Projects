using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Journey;

public interface IShipRouteChecker
{
    public void Go(ShipBase ship, Route route);
}
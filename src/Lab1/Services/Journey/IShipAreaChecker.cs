using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Journey;

public interface IShipAreaChecker
{
    public void GoArea(ShipBase ship, AreaBase area);
}
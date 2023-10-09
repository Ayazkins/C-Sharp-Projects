using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Journey;

public class ShipRouteChecker : IShipRouteChecker
{
    public ShipRouteChecker(Results result)
    {
        Result = result;
    }

    private Results Result { get; }

    public void Go(ShipBase ship, Route route)
    {
        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (route is null)
        {
            throw new ArgumentNullException(nameof(route));
        }

        var shipAreaChecker = new ShipAreaChecker(Result);
        foreach (AreaBase t in route.Areas)
        {
            shipAreaChecker.GoArea(ship, t);
            if (Result.Success)
            {
                return;
            }
        }
    }
}
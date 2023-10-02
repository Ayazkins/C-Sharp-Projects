using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Journey;

public class ShipRouteChecker : ShipAreaChecker
{
    public ShipRouteChecker(Results result)
        : base(result)
    {
    }

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

        foreach (AreaBase t in route.Areas)
        {
            GoArea(ship, t);
            if (NewResults.Success)
            {
                return;
            }
        }
    }
}
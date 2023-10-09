using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Journey;

public class ChooseBest : IChooseBest
{
    public string Choose(IEnumerable<ShipBase> ships, Route currentRoute)
    {
        if (ships == null)
        {
            throw new ArgumentNullException(nameof(ships));
        }

        var curBest = new Results();
        foreach (ShipBase ship in ships)
        {
            var result = new Results();
            var shipRouteChecker = new ShipRouteChecker(result);
            shipRouteChecker.Go(ship, currentRoute);
            if (result.Success)
            {
                if (!curBest.Success | (curBest.Success && result.FuelAmount < curBest.FuelAmount))
                {
                    curBest = result;
                }
            }
        }

        return curBest.Name;
    }
}
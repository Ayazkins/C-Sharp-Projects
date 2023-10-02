using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Journey;

public class ChooseBest
{
    public string Choose(IList<ShipBase> ships, Route currentRoute)
    {
        if (ships == null)
        {
            throw new ArgumentNullException(nameof(ships));
        }

        var curBest = new Results();
        for (int i = 0; i < ships.Count; ++i)
        {
            var result = new Results();
            var shipRouteChecker = new ShipRouteChecker(result);
            shipRouteChecker.Go(ships[i], currentRoute);
            if (result.Success)
            {
                if (!curBest.Success)
                {
                    curBest = result;
                }
                else
                {
                    if (result.FuelAmount < curBest.FuelAmount)
                    {
                        curBest = result;
                    }
                }
            }
        }

        return curBest.Name;
    }
}
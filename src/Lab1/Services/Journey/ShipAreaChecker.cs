using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Journey;

public class ShipAreaChecker : IShipAreaChecker
{
    private const int SpecialFuelTimes = 3;

    public ShipAreaChecker(Results result)
    {
        NewResults = result;
    }

    private Results NewResults { get; }

    public void GoArea(ShipBase ship, AreaBase area)
    {
        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (area is null)
        {
            throw new ArgumentNullException(nameof(area));
        }

        NewResults.Name = ship.Type;
        ship.TakeDamage(area.Obstacles);
        if (area is NebulaeDensity)
        {
            NewResults.Lost = !ship.JumpEngine.CanPass(area);
            if (!NewResults.Lost)
            {
                NewResults.FuelAmount += ship.JumpEngine.FuelCount(area) * SpecialFuelTimes;
                NewResults.TimeAmount += ship.JumpEngine.TimeCount(area);
            }
        }
        else
        {
            NewResults.Lost = !ship.Engine.CanPass(area);
            if (!NewResults.Lost)
            {
                NewResults.FuelAmount += ship.Engine.FuelCount(area);
                NewResults.TimeAmount += ship.Engine.TimeCount(area);
            }
        }

        NewResults.IsShipDied = ship.IsShipDead;
        NewResults.IsCrewDied = ship.IsCrewDead;
        NewResults.Success = NewResults is { IsShipDied: false, IsCrewDied: false, Lost: false };
    }
}
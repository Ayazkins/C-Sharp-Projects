using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class EngineBase
{
    protected EngineBase(int speed, int fuelConsumption)
    {
        Speed = speed;
        FuelConsumption = fuelConsumption;
    }

    public int Speed { get; private set; }

    public int FuelConsumption { get; private set; }

    public abstract bool CanPass(AreaBase area);

    public double TimeCount(AreaBase area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area));
        }

        return area.Range / Speed;
    }

    public double FuelCount(AreaBase area)
    {
        return TimeCount(area) * FuelConsumption;
    }
}
using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class EngineBase
{
    protected EngineBase(int speed, int fuelConsumption)
    {
        if (speed <= 0)
        {
            throw new ArgumentException("speed must be positive", nameof(speed));
        }

        if (fuelConsumption <= 0)
        {
            throw new ArgumentException("fuelConsumption must be positive", nameof(fuelConsumption));
        }

        Speed = speed;
        FuelConsumption = fuelConsumption;
    }

    public int Speed { get; }

    public int FuelConsumption { get; }

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
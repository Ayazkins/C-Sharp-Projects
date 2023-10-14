using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class JumpEngineBase
{
    protected JumpEngineBase(int range, int speed, int fuelConsumption)
    {
        if (range < 0)
        {
            throw new ArgumentException("range must be positive", nameof(range));
        }

        if (speed < 0)
        {
            throw new ArgumentException("speed must be positive", nameof(speed));
        }

        if (fuelConsumption < 0)
        {
            throw new ArgumentException("fuelConsumption must be positive", nameof(fuelConsumption));
        }

        JumpRange = range;
        Speed = speed;
        FuelConsumption = fuelConsumption;
    }

    public int JumpRange { get; }
    public int Speed { get; }
    public int FuelConsumption { get; }

    public double TimeCount(AreaBase area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area));
        }

        return area.Range / Speed;
    }

    public bool CanPass(AreaBase area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area));
        }

        return area.Range <= JumpRange;
    }

    public abstract double FuelCount(AreaBase area);
}
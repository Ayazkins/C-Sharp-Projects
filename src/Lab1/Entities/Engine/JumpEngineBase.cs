using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class JumpEngineBase
{
    protected JumpEngineBase(int range, int speed, int fuelConsumption)
    {
        JumpRange = range;
        Speed = speed;
        FuelConsumption = fuelConsumption;
    }

    public int JumpRange { get; private set; }
    public int Speed { get; private set; }
    public int FuelConsumption { get; private set; }

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
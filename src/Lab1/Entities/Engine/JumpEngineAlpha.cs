using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class JumpEngineAlpha : JumpEngineBase
{
    private const int SpeedC = 50;
    private const int FuelConsumptionC = 50;
    private const int RangeC = 500;

    public JumpEngineAlpha()
        : base(RangeC, SpeedC, FuelConsumptionC)
    {
    }

    public override double FuelCount(AreaBase area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area));
        }

        return area.Range / this.Speed;
    }
}
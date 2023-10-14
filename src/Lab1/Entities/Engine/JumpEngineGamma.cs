using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class JumpEngineGamma : JumpEngineBase
{
    private const int SpeedC = 200;
    private const int FuelConsumptionC = 50;
    private const int RangeC = 2000;

    public JumpEngineGamma()
        : base(RangeC, SpeedC, FuelConsumptionC)
    {
    }

    public override double FuelCount(AreaBase area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area));
        }

        return (area.Range / this.Speed) * (area.Range / this.Speed);
    }
}
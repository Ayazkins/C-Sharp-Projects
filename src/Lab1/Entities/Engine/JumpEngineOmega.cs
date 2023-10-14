using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class JumpEngineOmega : JumpEngineBase
{
    private const int SpeedC = 100;
    private const int FuelConsumptionC = 50;
    private const int RangeC = 1000;

    public JumpEngineOmega()
        : base(RangeC, SpeedC, FuelConsumptionC)
    {
    }

    public override double FuelCount(AreaBase area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area));
        }

        return (area.Range / Speed) * double.Log2(area.Range / Speed);
    }
}
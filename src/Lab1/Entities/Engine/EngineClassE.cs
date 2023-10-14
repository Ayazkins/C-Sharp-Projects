using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineClassE : EngineBase
{
    private const int SpeedC = 20;
    private const int FuelConsumptionC = 30;

    public EngineClassE()
        : base(SpeedC, FuelConsumptionC)
    {
    }

    public override bool CanPass(AreaBase area)
    {
        return area is not NebulaeDensity;
    }
}
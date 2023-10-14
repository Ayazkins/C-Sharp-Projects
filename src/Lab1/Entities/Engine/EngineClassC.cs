using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineClassC : EngineBase
{
    private const int SpeedC = 10;
    private const int FuelConsumptionC = 10;

    public EngineClassC()
        : base(SpeedC, FuelConsumptionC)
    {
    }

    public override bool CanPass(AreaBase area)
    {
        return area is Cosmos;
    }
}
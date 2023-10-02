using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class NullJumpEngine : JumpEngineBase
{
    private const int SpeedC = 0;
    private const int FuelConsumptionC = 0;
    private const int RangeC = 0;

    public NullJumpEngine()
        : base(RangeC, SpeedC, FuelConsumptionC)
    {
    }

    public override double FuelCount(AreaBase area)
    {
        return 0;
    }
}
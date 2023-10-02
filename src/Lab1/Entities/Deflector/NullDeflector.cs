namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class NullDeflector : DeflectorBase
{
    private const int MaxHitPoints = 0;
    public NullDeflector()
        : base(MaxHitPoints)
    {
    }
}
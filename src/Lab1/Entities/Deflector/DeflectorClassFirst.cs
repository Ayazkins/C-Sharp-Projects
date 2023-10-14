namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClassFirst : DeflectorBase
{
    private const int MaxHitPoints = 50;

    public DeflectorClassFirst(bool photonHitPoints = false)
        : base(MaxHitPoints, photonHitPoints)
    {
    }
}
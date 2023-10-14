namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClassThird : DeflectorBase
{
    private const int MaxHitPoints = 500;

    public DeflectorClassThird(bool photonHitPoints = false)
        : base(MaxHitPoints, photonHitPoints)
    {
    }
}
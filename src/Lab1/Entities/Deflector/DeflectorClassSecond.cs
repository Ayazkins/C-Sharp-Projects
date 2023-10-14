namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClassSecond : DeflectorBase
{
    private const int MaxHitPoints = 150;

    public DeflectorClassSecond(bool photonHitPoints = false)
        : base(MaxHitPoints, photonHitPoints)
    {
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClass2 : DeflectorBase
{
    private const int MaxHitPoints = 150;

    public DeflectorClass2(bool photonHP = false)
        : base(MaxHitPoints, photonHP)
    {
    }
}
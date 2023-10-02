namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClass1 : DeflectorBase
{
    private const int MaxHitPoints = 50;

    public DeflectorClass1(bool photonHP = false)
        : base(MaxHitPoints, photonHP)
    {
    }
}
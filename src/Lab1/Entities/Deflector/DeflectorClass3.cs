namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClass3 : DeflectorBase
{
    private const int MaxHitPoints = 500;

    public DeflectorClass3(bool photonHP = false)
        : base(MaxHitPoints, photonHP)
    {
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public abstract class ObstacleBase
{
    protected ObstacleBase(int damage)
    {
        Damage = damage;
    }

    public int Damage { get; protected set; }

    public bool IsAlive => Damage > 0;

    public void RefuseDamage(int currentHitPoints)
    {
        Damage -= currentHitPoints;
        if (Damage < 0)
        {
            Damage = 0;
        }
    }
}
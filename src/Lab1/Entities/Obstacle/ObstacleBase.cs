using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public abstract class ObstacleBase
{
    protected ObstacleBase(int damage, int amount)
    {
        if (damage < 0)
        {
            throw new ArgumentException("damage must not be >= 0", nameof(damage));
        }

        Damage = damage * amount;
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
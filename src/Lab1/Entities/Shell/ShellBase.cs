using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

public abstract class ShellBase
{
    protected ShellBase(int maxHitPoints)
    {
        if (maxHitPoints <= 0)
        {
            throw new ArgumentException("range must be positive", nameof(maxHitPoints));
        }

        CurrentHitPoints = maxHitPoints;
    }

    public bool IsAlive => this.CurrentHitPoints > 0;
    public int CurrentHitPoints { get; private set; }

    public void TakeDamage(ObstacleBase? obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (obstacle is AntiMateria)
        {
            return;
        }

        int beforeBattle = CurrentHitPoints;

        CurrentHitPoints -= obstacle.Damage;

        if (CurrentHitPoints < 0)
        {
            CurrentHitPoints = 0;
        }

        obstacle.RefuseDamage(beforeBattle);
    }
}
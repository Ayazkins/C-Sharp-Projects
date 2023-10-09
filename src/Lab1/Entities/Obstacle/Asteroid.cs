namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Asteroid : ObstacleBase
{
    private const int MaxDamage = 15;

    public Asteroid(int amount)
        : base(MaxDamage, amount)
    {
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class AntiMateria : ObstacleBase
{
    private const int MaxDamage = 1;

    public AntiMateria(int amount)
        : base(MaxDamage, amount)
    {
    }
}
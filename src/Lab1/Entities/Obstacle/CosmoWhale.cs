namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class CosmoWhale : ObstacleBase
{
    private const int MaxDamage = 500;

    public CosmoWhale(int population)
        : base(MaxDamage, population)
    {
    }
}
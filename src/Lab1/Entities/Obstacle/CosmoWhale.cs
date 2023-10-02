namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class CosmoWhale : ObstacleBase
{
    private const int MaxDamage = 500;

    public CosmoWhale(int population = 1)
        : base(MaxDamage)
    {
        Population = population;
        this.Damage *= population;
    }

    public int Population { get; private set; }
}
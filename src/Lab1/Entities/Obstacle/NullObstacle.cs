namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class NullObstacle : ObstacleBase
{
    private const int MaxDamage = 0;

    public NullObstacle()
        : base(MaxDamage)
    {
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Meteor : ObstacleBase
{
    private const int MaxDamage = 50;

    public Meteor(int amount)
        : base(MaxDamage, amount)
    {
    }
}
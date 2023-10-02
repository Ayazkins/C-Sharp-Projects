using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

public abstract class AreaBase
{
    protected AreaBase(int range, ObstacleBase obstacle)
    {
        Range = range;
        Obstacle = obstacle;
    }

    public int Range { get; private set; }
    public ObstacleBase Obstacle { get; private set; }
}
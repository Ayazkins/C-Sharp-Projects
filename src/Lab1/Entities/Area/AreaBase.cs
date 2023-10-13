using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

public abstract class AreaBase
{
    protected AreaBase(int range, ObstacleBase obstacles)
    {
        if (range <= 0)
        {
            throw new NegativeValueException(nameof(range));
        }

        Range = range;
        Obstacles = obstacles;
    }

    public int Range { get; }
    public ObstacleBase Obstacles { get; }
}
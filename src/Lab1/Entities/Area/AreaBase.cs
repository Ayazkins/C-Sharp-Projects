using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

public abstract class AreaBase
{
    protected AreaBase(int range, ObstacleBase obstacles)
    {
        if (range <= 0)
        {
            throw new ArgumentException("range must be positive", nameof(range));
        }

        Range = range;
        Obstacles = obstacles;
    }

    public int Range { get; }
    public ObstacleBase Obstacles { get; }
}
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

public class Cosmos : AreaBase
{
    public Cosmos(int range, Meteor obstacle)
        : base(range, obstacle)
    {
    }

    public Cosmos(int range, Asteroid obstacle)
        : base(range, obstacle)
    {
    }

    public Cosmos(int range)
        : base(range, new NullObstacle())
    {
    }
}
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

public class NebulaN : AreaBase
{
    public NebulaN(int range, CosmoWhale obstacle)
        : base(range, obstacle)
    {
    }

    public NebulaN(int range)
        : base(range, new NullObstacle())
    {
    }
}
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

public class NebulaeDensity : AreaBase
{
    public NebulaeDensity(int range, AntiMateria obstacle)
        : base(range, obstacle)
    {
    }

    public NebulaeDensity(int range)
        : base(range, new NullObstacle())
    {
    }
}
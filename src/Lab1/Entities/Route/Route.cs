using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class Route
{
    public Route(IList<AreaBase> areas)
    {
        Areas = areas;
    }

    public IList<AreaBase> Areas { get; private set; }
}
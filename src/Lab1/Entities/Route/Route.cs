using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class Route
{
    public Route(IEnumerable<AreaBase> areas)
    {
        if (areas is null)
        {
            throw new ArgumentNullException(nameof(areas));
        }

        if (areas.Any(a => a is null))
        {
            throw new ArgumentNullException(nameof(areas));
        }

        Areas = areas;
    }

    public IEnumerable<AreaBase> Areas { get; private set; }
}
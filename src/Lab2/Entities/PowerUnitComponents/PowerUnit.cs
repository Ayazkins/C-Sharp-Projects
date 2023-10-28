using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitComponents;

public class PowerUnit : DetailBase
{
    public PowerUnit(string name, int energy)
        : base(name)
    {
        if (energy <= 0)
        {
            throw new NotPositiveValue(nameof(energy));
        }

        Energy = energy;
    }

    public int Energy { get; set; }
}
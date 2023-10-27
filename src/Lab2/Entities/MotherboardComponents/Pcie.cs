using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;

public class Pcie : DetailBase
{
    public Pcie(string name, int pins)
        : base(name)
    {
        if (pins <= 0)
        {
            throw new NotPositiveValue(nameof(pins));
        }

        Pins = pins;
        Used = false;
    }

    public bool Used { get; set; }
    public int Pins { get; }
}
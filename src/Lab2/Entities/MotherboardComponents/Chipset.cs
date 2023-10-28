using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;

public class Chipset : DetailBase
{
    public Chipset(string name, double memoryFrequency, bool xmp)
        : base(name)
    {
        if (memoryFrequency <= 0)
        {
            throw new NotPositiveValue(nameof(memoryFrequency));
        }

        MemoryFrequency = memoryFrequency;
        XMP = xmp;
    }

    public double MemoryFrequency { get; }

    public bool XMP { get; }
}
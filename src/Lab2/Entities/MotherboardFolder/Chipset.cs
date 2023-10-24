namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;

public class Chipset : DetailBase
{
    public Chipset(string name, double memoryFrequency, bool xmp)
        : base(name)
    {
        MemoryFrequency = memoryFrequency;
        XMP = xmp;
    }

    public double MemoryFrequency { get; }

    public bool XMP { get; }
}
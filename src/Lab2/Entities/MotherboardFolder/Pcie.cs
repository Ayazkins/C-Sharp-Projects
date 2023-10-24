namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIEFolder;

public class Pcie : DetailBase
{
    public Pcie(string name, int pins)
        : base(name)
    {
        Pins = pins;
        Used = false;
    }

    public bool Used { get; set; }
    public int Pins { get; }
}
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIEFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.DIsks;

public class Ssd : Hdd
{
    public Ssd(string name, int capacity, int speed, int energyConsumption, Pcie? isSata)
        : base(name, capacity, speed, energyConsumption)
    {
        Pcie = isSata;
    }

    public Pcie? Pcie { get; }
}
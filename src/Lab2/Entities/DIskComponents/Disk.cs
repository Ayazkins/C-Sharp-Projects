using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.DIskComponents;

public class Disk : DetailBase
{
    public Disk(string name, int capacity, int speed, int energyConsumption, Pcie? pcie = null)
        : base(name)
    {
        if (capacity <= 0)
        {
            throw new NotPositiveValue(nameof(capacity));
        }

        if (speed <= 0)
        {
            throw new NotPositiveValue(nameof(speed));
        }

        if (energyConsumption <= 0)
        {
            throw new NotPositiveValue(nameof(energyConsumption));
        }

        this.Pcie = pcie;
        Capacity = capacity;
        Speed = speed;
        EnergyConsumption = energyConsumption;
    }

    public Pcie? Pcie { get; }
    public int Capacity { get; set; }
    public int Speed { get; set; }
    public int EnergyConsumption { get; set; }
}
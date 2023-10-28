using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardComponents;

public class Videocard : DetailBase
{
    public Videocard(string name, Pcie pcie, int energyConsumption, double frequency, int memory, int length, int width)
        : base(name)
    {
        if (memory <= 0)
        {
            throw new NotPositiveValue(nameof(memory));
        }

        if (energyConsumption <= 0)
        {
            throw new NotPositiveValue(nameof(energyConsumption));
        }

        if (frequency <= 0)
        {
            throw new NotPositiveValue(nameof(frequency));
        }

        if (length <= 0)
        {
            throw new NotPositiveValue(nameof(length));
        }

        if (width <= 0)
        {
            throw new NotPositiveValue(nameof(width));
        }

        Pcie = pcie;
        EnergyConsumption = energyConsumption;
        Frequency = frequency;
        Memory = memory;
        Length = length;
        Width = width;
    }

    public Pcie Pcie { get; }
    public int EnergyConsumption { get; }
    public double Frequency { get; }
    public int Memory { get; }
    public int Length { get; }
    public int Width { get; }

    public VideocardBuilder Direct()
    {
        var videocardBuilder = new VideocardBuilder();
        videocardBuilder
            .SetName(Name)
            .SetFrequency(Frequency)
            .SetMemory(Memory)
            .SetLength(Length)
            .SetEnergyConsumption(EnergyConsumption)
            .SetPci(Pcie)
            .SetWidth(Width);
        return videocardBuilder;
    }
}
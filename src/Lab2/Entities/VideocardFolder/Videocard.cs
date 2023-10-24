using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIEFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardFolder;

public class Videocard : DetailBase
{
    public Videocard(string name, Pcie pcie, int energyConsumption, double frequency, int memory, int length, int width)
        : base(name)
    {
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
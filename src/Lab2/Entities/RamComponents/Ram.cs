using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamProfileComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;

public class Ram : DetailBase
{
    public Ram(
        string name,
        Ddr ddr,
        FormFactor formFactor,
        int energyConsumption,
        int memory,
        IReadOnlyCollection<JedecAndVoltage> pairsOfJedecAndVoltage,
        IReadOnlyCollection<RamProfile> profiles)
        : base(name)
    {
        if (energyConsumption <= 0)
        {
            throw new NotPositiveValue(nameof(energyConsumption));
        }

        if (memory <= 0)
        {
            throw new NotPositiveValue(nameof(memory));
        }

        Ddr = ddr;
        FormFactor = formFactor;
        EnergyConsumption = energyConsumption;
        Memory = memory;
        PairsOfJedecAndVoltage = pairsOfJedecAndVoltage;
        Profiles = profiles;
    }

    public Ddr Ddr { get; }
    public FormFactor FormFactor { get; }
    public int EnergyConsumption { get; }
    public int Memory { get; }
    public IReadOnlyCollection<JedecAndVoltage> PairsOfJedecAndVoltage { get; }
    public IReadOnlyCollection<RamProfile> Profiles { get; }

    public RamBuilder Direct()
    {
        RamBuilder ramBuilder = new RamBuilder()
            .SetName(Name)
            .SetMemory(Memory)
            .SetProfiles(Profiles)
            .SetFormFactor(FormFactor)
            .SetEnergyConsumption(EnergyConsumption)
            .SetJedecVoltage(PairsOfJedecAndVoltage)
            .SetDDR(Ddr);
        return ramBuilder;
    }
}
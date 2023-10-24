using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;

public class Ram : DetailBase
{
    public Ram(
        string name,
        Ddr ddr,
        FormFactor formFactor,
        int energyConsumption,
        int memory,
        IReadOnlyCollection<JedecAndVoltage> pairsOfJedecAndVoltage,
        IReadOnlyCollection<Profile> profiles)
        : base(name)
    {
        Ddr = ddr;
        FormFactor = formFactor;
        EnergyConsumption = energyConsumption;
        Memory = memory;
        PairsOFJedecAndVoltage = pairsOfJedecAndVoltage;
        Profiles = profiles;
    }

    public Ddr Ddr { get; }
    public FormFactor FormFactor { get; }
    public int EnergyConsumption { get; }
    public int Memory { get; }
    public IReadOnlyCollection<JedecAndVoltage> PairsOFJedecAndVoltage { get; }
    public IReadOnlyCollection<Profile> Profiles { get; }

    public RamBuilder Direct()
    {
        RamBuilder ramBuilder = new RamBuilder()
            .SetName(Name)
            .SetMemory(Memory)
            .SetProfiles(Profiles)
            .SetFormFactor(FormFactor)
            .SetEnergyConsumption(EnergyConsumption)
            .SetJedecVoltage(PairsOFJedecAndVoltage)
            .SetDDR(Ddr);
        return ramBuilder;
    }
}
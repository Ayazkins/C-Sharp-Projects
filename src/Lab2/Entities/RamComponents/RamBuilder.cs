using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamProfileComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;

public class RamBuilder
{
    private Ddr? _ddr;
    private string? _name;
    private FormFactor? _formFactor;
    private int _energyConsumption;
    private int _memory;
    private IReadOnlyCollection<JedecAndVoltage>? _pairsOFJedecAndVoltage;
    private IReadOnlyCollection<RamProfile>? _profiles;

    public RamBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public RamBuilder SetDDR(Ddr ddr)
    {
        _ddr = ddr;
        return this;
    }

    public RamBuilder SetFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RamBuilder SetEnergyConsumption(int energyConsumption)
    {
        _energyConsumption = energyConsumption;
        return this;
    }

    public RamBuilder SetMemory(int memory)
    {
        _memory = memory;
        return this;
    }

    public RamBuilder SetJedecVoltage(IReadOnlyCollection<JedecAndVoltage> jedecAndVoltages)
    {
        _pairsOFJedecAndVoltage = jedecAndVoltages;
        return this;
    }

    public RamBuilder SetProfiles(IReadOnlyCollection<RamProfile> profiles)
    {
        _profiles = profiles;
        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _name ?? throw new ObjectShouldBeNotNull(nameof(_name)),
            _ddr ?? throw new ObjectShouldBeNotNull(nameof(_ddr)),
            _formFactor ?? throw new ObjectShouldBeNotNull(nameof(_formFactor)),
            _energyConsumption,
            _memory,
            _pairsOFJedecAndVoltage ?? throw new ObjectShouldBeNotNull(nameof(_pairsOFJedecAndVoltage)),
            _profiles ?? throw new ObjectShouldBeNotNull(nameof(_profiles)));
    }
}
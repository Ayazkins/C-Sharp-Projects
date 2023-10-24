using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;

public class RamBuilder
{
    private Ddr? _ddr;
    private string? _name;
    private FormFactor? _formFactor;
    private int _energyConsumption;
    private int _memory;
    private IReadOnlyCollection<JedecAndVoltage>? _pairsOFJedecAndVoltage;
    private IReadOnlyCollection<Profile>? _profiles;

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

    public RamBuilder SetProfiles(IReadOnlyCollection<Profile> profiles)
    {
        _profiles = profiles;
        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _energyConsumption,
            _memory,
            _pairsOFJedecAndVoltage ?? throw new ArgumentNullException(nameof(_pairsOFJedecAndVoltage)),
            _profiles ?? throw new ArgumentNullException(nameof(_profiles)));
    }
}
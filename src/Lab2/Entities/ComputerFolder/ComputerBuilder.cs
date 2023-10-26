using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPUFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIsks;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;

public class ComputerBuilder
{
    private string? _name;
    private Motherboard? _motherboard;
    private ComputerCase? _computerCase;
    private Videocard? _videocard;
    private Cpu? _cpu;
    private IReadOnlyCollection<Hdd>? _disks;
    private PowerUnit? _powerUnit;
    private Cooler? _cooler;
    private WiFi? _wiFi;
    private IReadOnlyCollection<Ram>? _rams;
    private IValidator _validator;

    public ComputerBuilder(IValidator validator)
    {
        _validator = validator;
    }

    public ComputerBuilder SetName(string? name)
    {
        _name = name;
        return this;
    }

    public ComputerBuilder SetMotherboard(Motherboard? motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ComputerBuilder SetVideocard(Videocard? videocard)
    {
        _videocard = videocard;
        return this;
    }

    public ComputerBuilder SetCpu(Cpu? cpu)
    {
        _cpu = cpu;
        return this;
    }

    public ComputerBuilder SetPowerUnit(PowerUnit? powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public ComputerBuilder SetCooler(Cooler? cooler)
    {
        _cooler = cooler;
        return this;
    }

    public ComputerBuilder SetWiFi(WiFi? wiFi)
    {
        _wiFi = wiFi;
        return this;
    }

    public ComputerBuilder SetDisks(IReadOnlyCollection<Hdd>? disks)
    {
        _disks = disks;
        return this;
    }

    public ComputerBuilder SetRams(IReadOnlyCollection<Ram>? rams)
    {
        _rams = rams;
        return this;
    }

    public ComputerBuilder SetCase(ComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public PcBuildResult Build()
    {
        var computer = new Computer(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _motherboard ?? throw new ArgumentNullException(nameof(_name)),
            _videocard,
            _cpu ?? throw new ArgumentNullException(nameof(_cpu)),
            _disks ?? throw new ArgumentNullException(nameof(_disks)),
            _powerUnit ?? throw new ArgumentNullException(nameof(_powerUnit)),
            _cooler ?? throw new ArgumentNullException(nameof(_cooler)),
            _wiFi,
            _rams ?? throw new ArgumentNullException(nameof(_rams)),
            _computerCase ?? throw new ArgumentNullException(nameof(_computerCase)));
        ValidatorResult validatorResult = _validator.Validate(computer);
        if (validatorResult is ValidatorResult.Fault)
        {
            return new PcBuildResult(null, validatorResult);
        }

        return new PcBuildResult(computer, validatorResult);
    }
}
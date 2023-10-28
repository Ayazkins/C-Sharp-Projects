using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIskComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class ComputerBuilder
{
    private string? _name;
    private Motherboard? _motherboard;
    private ComputerCase? _computerCase;
    private Videocard? _videocard;
    private Cpu? _cpu;
    private IReadOnlyCollection<Disk>? _disks;
    private PowerUnit? _powerUnit;
    private Cooler? _cooler;
    private WiFi? _wiFi;
    private IReadOnlyCollection<Ram>? _rams;
    private IValidator _validator;

    public ComputerBuilder(IValidator validator)
    {
        _validator = validator;
    }

    public ValidatorResult? ValidatorResult { get; private set; }

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

    public ComputerBuilder SetDisks(IReadOnlyCollection<Disk>? disks)
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

    public Computer Build()
    {
        var computer = new Computer(
            _name ?? throw new ObjectShouldBeNotNull(nameof(_name)),
            _motherboard ?? throw new ObjectShouldBeNotNull(nameof(_name)),
            _videocard,
            _cpu ?? throw new ObjectShouldBeNotNull(nameof(_cpu)),
            _disks ?? throw new ObjectShouldBeNotNull(nameof(_disks)),
            _powerUnit ?? throw new ObjectShouldBeNotNull(nameof(_powerUnit)),
            _cooler ?? throw new ObjectShouldBeNotNull(nameof(_cooler)),
            _wiFi,
            _rams ?? throw new ObjectShouldBeNotNull(nameof(_rams)),
            _computerCase ?? throw new ObjectShouldBeNotNull(nameof(_computerCase)));
        ValidatorResult = _validator.Validate(computer);
        if (ValidatorResult is ValidatorResult.Fault)
        {
            throw new FailedValidationException(nameof(computer));
        }

        return computer;
    }
}
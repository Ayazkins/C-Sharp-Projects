using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BiosComponents;

public class BiosBuilder
{
    private double _version;
    private string? _name;
    private IReadOnlyCollection<Cpu>? _cpuList;

    public BiosBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public BiosBuilder SetVersion(double version)
    {
        _version = version;
        return this;
    }

    public BiosBuilder SetCpu(IReadOnlyCollection<Cpu> list)
    {
        _cpuList = list;
        return this;
    }

    public Bios Build()
    {
        return new Bios(
            _name ?? throw new ObjectShouldBeNotNull(nameof(_name)),
            _cpuList ?? throw new ObjectShouldBeNotNull(nameof(_cpuList)),
            _version);
    }
}
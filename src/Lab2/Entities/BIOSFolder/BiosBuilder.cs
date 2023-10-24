using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPUFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSFolder;

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
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _cpuList ?? throw new ArgumentNullException(nameof(_cpuList)),
            _version);
    }
}
using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamProfileComponents;

public class RamProfileBuilder
{
    private IReadOnlyCollection<int>? _timings;
    private double _voltage;
    private int _frequency;
    private string? _type;
    private string? _name;

    public RamProfileBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public RamProfileBuilder SetVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public RamProfileBuilder SetType(string type)
    {
        _type = type;
        return this;
    }

    public RamProfileBuilder SetFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public RamProfileBuilder SetTiming(IReadOnlyCollection<int> timings)
    {
        _timings = timings;
        return this;
    }

    public RamProfile Build()
    {
        return new RamProfile(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _type ?? throw new ArgumentNullException(nameof(_name)),
            _voltage,
            _frequency,
            _timings ?? throw new ArgumentNullException(nameof(_timings)));
    }
}
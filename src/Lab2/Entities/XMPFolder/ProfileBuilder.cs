using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPFolder;

public class ProfileBuilder
{
    private IReadOnlyCollection<int>? _timings;
    private double _voltage;
    private int _frequency;
    private string? _type;
    private string? _name;

    public ProfileBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ProfileBuilder SetVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public ProfileBuilder SetType(string type)
    {
        _type = type;
        return this;
    }

    public ProfileBuilder SetFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public ProfileBuilder SetTiming(IReadOnlyCollection<int> timings)
    {
        _timings = timings;
        return this;
    }

    public Profile Build()
    {
        return new Profile(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _type ?? throw new ArgumentNullException(nameof(_name)),
            _voltage,
            _frequency,
            _timings ?? throw new ArgumentNullException(nameof(_timings)));
    }
}
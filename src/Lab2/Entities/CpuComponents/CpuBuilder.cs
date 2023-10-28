using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;

public class CpuBuilder
{
    private double _coreFrequency;
    private int _cores;
    private Socket? _socket;
    private bool _videocard;
    private double _memoryFrequency;
    private int _tdp;
    private int _energyConsumption;
    private string? _name;

    public CpuBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public CpuBuilder SetCores(int value)
    {
        _cores = value;
        return this;
    }

    public CpuBuilder SetSocket(Socket value)
    {
        _socket = value;
        return this;
    }

    public CpuBuilder SetVideocard(bool value)
    {
        _videocard = value;
        return this;
    }

    public CpuBuilder SetMemoryFrequency(double value)
    {
        _memoryFrequency = value;
        return this;
    }

    public CpuBuilder SetTdp(int value)
    {
        _tdp = value;
        return this;
    }

    public CpuBuilder SetEnergyConsumption(int value)
    {
        _energyConsumption = value;
        return this;
    }

    public CpuBuilder SetCoreFrequency(double value)
    {
        _coreFrequency = value;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _name ?? throw new ObjectShouldBeNotNull(nameof(_name)),
            _coreFrequency,
            _cores,
            _socket ?? throw new ObjectShouldBeNotNull(nameof(_socket)),
            _videocard,
            _memoryFrequency,
            _tdp,
            _energyConsumption);
    }
}
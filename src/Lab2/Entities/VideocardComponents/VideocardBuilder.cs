using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardComponents;

public class VideocardBuilder
{
    private Pcie? _pcie;
    private int _energyConsumption;
    private double _frequency;
    private int _memory;
    private int _length;
    private int _width;
    private string? _name;

    public VideocardBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public VideocardBuilder SetWidth(int width)
    {
        _width = width;
        return this;
    }

    public VideocardBuilder SetLength(int length)
    {
        _length = length;
        return this;
    }

    public VideocardBuilder SetFrequency(double value)
    {
        _frequency = value;
        return this;
    }

    public VideocardBuilder SetMemory(int value)
    {
        _memory = value;
        return this;
    }

    public VideocardBuilder SetPci(Pcie pCie)
    {
        _pcie = pCie;
        return this;
    }

    public VideocardBuilder SetEnergyConsumption(int energy)
    {
        _energyConsumption = energy;
        return this;
    }

    public Videocard Build()
    {
        return new Videocard(
            _name ?? throw new ObjectShouldBeNotNull(nameof(_name)),
            _pcie ?? throw new ObjectShouldBeNotNull(nameof(_pcie)),
            _energyConsumption,
            _frequency,
            _memory,
            _length,
            _width);
    }
}
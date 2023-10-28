using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseComponents;

public class CaseBuilder
{
    private int _height;
    private int _length;
    private int _width;
    private int _lengthOfVideo;
    private int _widthOfVide;
    private string? _name;
    private IReadOnlyCollection<FormFactor>? _formFactors;
    public CaseBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public CaseBuilder SetHeight(int height)
    {
        _height = height;
        return this;
    }

    public CaseBuilder SetWidth(int width)
    {
        _width = width;
        return this;
    }

    public CaseBuilder SetLength(int length)
    {
        _length = length;
        return this;
    }

    public CaseBuilder SetLengthOfVideocard(int length)
    {
        _lengthOfVideo = length;
        return this;
    }

    public CaseBuilder SetWidthOfVideocard(int width)
    {
        _widthOfVide = width;
        return this;
    }

    public CaseBuilder SetFormFactors(IReadOnlyCollection<FormFactor> formFactors)
    {
        _formFactors = formFactors;
        return this;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(
            _name ?? throw new ObjectShouldBeNotNull(nameof(_name)),
            _height,
            _width,
            _length,
            _lengthOfVideo,
            _widthOfVide,
            _formFactors ?? throw new ObjectShouldBeNotNull(nameof(_formFactors)));
    }
}

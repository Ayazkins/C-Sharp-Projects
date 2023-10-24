using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SocketFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPUFolder;

public class CoolerBuilder
{
    private int _height;
    private int _width;
    private int _length;
    private IReadOnlyCollection<Socket>? _supportedSockets;
    private int _tdp;
    private string? _name;

    public CoolerBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public CoolerBuilder SetHeight(int height)
    {
        _height = height;
        return this;
    }

    public CoolerBuilder SetWidth(int width)
    {
        _width = width;
        return this;
    }

    public CoolerBuilder SetTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CoolerBuilder SetLength(int length)
    {
        _length = length;
        return this;
    }

    public CoolerBuilder SetSockets(IReadOnlyCollection<Socket> sockets)
    {
        _supportedSockets = sockets;
        return this;
    }

    public Cooler Build()
    {
        return new Cooler(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _width,
            _height,
            _length,
            _tdp,
            _supportedSockets ?? throw new ArgumentNullException(nameof(_supportedSockets)));
    }
}
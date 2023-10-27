using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;

public class Cooler : DetailBase
{
    public Cooler(string name, int width, int height, int length, int tdp, IReadOnlyCollection<Socket> supportedSockets)
        : base(name)
    {
        if (height <= 0)
        {
            throw new NotPositiveValue(nameof(height));
        }

        if (width <= 0)
        {
            throw new NotPositiveValue(nameof(width));
        }

        if (length <= 0)
        {
            throw new NotPositiveValue(nameof(length));
        }

        if (tdp <= 0)
        {
            throw new NotPositiveValue(nameof(tdp));
        }

        Width = width;
        Height = height;
        Length = length;
        TDP = tdp;
        SupportedSockets = supportedSockets;
    }

    public int Height { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }
    public IReadOnlyCollection<Socket> SupportedSockets { get; set; }
    public int TDP { get; set; }

    public CoolerBuilder Direct()
    {
        return new CoolerBuilder()
            .SetLength(Length)
            .SetHeight(Height)
            .SetName(Name)
            .SetWidth(Width)
            .SetSockets(SupportedSockets)
            .SetTdp(TDP);
    }
}
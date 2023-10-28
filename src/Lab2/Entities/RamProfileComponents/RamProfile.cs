using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamProfileComponents;

public class RamProfile : DetailBase
{
    public RamProfile(string name, string type, double voltage, int frequency, IReadOnlyCollection<int> timings)
        : base(name)
    {
        if (voltage <= 0)
        {
            throw new NotPositiveValue(nameof(voltage));
        }

        if (frequency <= 0)
        {
            throw new NotPositiveValue(nameof(frequency));
        }

        Type = type;
        Voltage = voltage;
        Frequency = frequency;
        Timings = timings;
    }

    public IReadOnlyCollection<int> Timings { get; }
    public double Voltage { get; }
    public int Frequency { get; }
    public string Type { get; }
}
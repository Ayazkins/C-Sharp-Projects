using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPFolder;

public class Profile : DetailBase
{
    public Profile(string name, string type, double voltage, int frequency, IReadOnlyCollection<int> timings)
        : base(name)
    {
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
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BiosComponents;

public class Bios : DetailBase
{
    public Bios(string name, IReadOnlyCollection<Cpu> cpuList, double version)
        : base(name)
    {
        if (version <= 0)
        {
            throw new NotPositiveValue(nameof(version));
        }

        Version = version;
        CpuList = cpuList;
    }

    public double Version { get; }

    public IReadOnlyCollection<Cpu> CpuList { get; }

    public BiosBuilder Direct()
    {
        BiosBuilder biosBuilder = new BiosBuilder()
            .SetName(Name)
            .SetCpu(CpuList)
            .SetVersion(Version);
        return biosBuilder;
    }
}
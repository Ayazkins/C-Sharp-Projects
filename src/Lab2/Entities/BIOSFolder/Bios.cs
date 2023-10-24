using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPUFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSFolder;

public class Bios : DetailBase
{
    public Bios(string name, IReadOnlyCollection<Cpu> cpuList, double version)
        : base(name)
    {
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
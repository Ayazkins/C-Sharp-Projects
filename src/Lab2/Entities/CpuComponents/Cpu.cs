using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;

public class Cpu : DetailBase
{
    public Cpu(string name, double coreFrequency, int cores, Socket socket, bool videocard, double memoryFrequency, int tdp, int energyConsumption)
        : base(name)
    {
        if (coreFrequency <= 0)
        {
            throw new NotPositiveValue(nameof(coreFrequency));
        }

        if (cores <= 0)
        {
            throw new NotPositiveValue(nameof(cores));
        }

        if (memoryFrequency <= 0)
        {
            throw new NotPositiveValue(nameof(memoryFrequency));
        }

        if (energyConsumption <= 0)
        {
            throw new NotPositiveValue(nameof(energyConsumption));
        }

        if (tdp <= 0)
        {
            throw new NotPositiveValue(nameof(tdp));
        }

        CoreFrequency = coreFrequency;
        Cores = cores;
        Socket = socket;
        Videocard = videocard;
        MemoryFrequency = memoryFrequency;
        EnergyConsumption = energyConsumption;
        Tdp = tdp;
    }

    public double CoreFrequency { get; }
    public int Cores { get; }
    public Socket Socket { get; }
    public bool Videocard { get; }
    public double MemoryFrequency { get; }
    public int Tdp { get; set; }
    public int EnergyConsumption { get; }

    public CpuBuilder Direct()
    {
        CpuBuilder cpuBuilder = new CpuBuilder()
            .SetCores(Cores)
            .SetName(Name)
            .SetSocket(Socket)
            .SetEnergyConsumption(EnergyConsumption)
            .SetVideocard(Videocard)
            .SetCoreFrequency(CoreFrequency)
            .SetMemoryFrequency(MemoryFrequency)
            .SetTdp(Tdp);
        return cpuBuilder;
    }
}
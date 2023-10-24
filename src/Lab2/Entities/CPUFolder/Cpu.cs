using Itmo.ObjectOrientedProgramming.Lab2.Entities.SocketFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPUFolder;

public class Cpu : DetailBase
{
    public Cpu(string name, double coreFrequency, int cores, Socket socket, bool videocard, double memoryFrequency, int tdp, int energyConsumption)
        : base(name)
    {
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
            .SetTDP(Tdp);
        return cpuBuilder;
    }
}
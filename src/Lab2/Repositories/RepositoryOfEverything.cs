using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIskComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class RepositoryOfEverything
{
    public RepositoryOfEverything(
        IRepository<Cpu> cpuStorage,
        IRepository<Motherboard> motherboardStorage,
        IRepository<PowerUnit> powerUnitStorage,
        IRepository<Videocard> videocardStorage,
        IRepository<Cooler> coolerStorage,
        IRepository<Ram> ramStorage,
        IRepository<Disk> diskStorage,
        IRepository<ComputerCase> computerCaseStorage,
        IRepository<WiFi> wifiStorage)
    {
        CpuStorage = cpuStorage;
        MotherBoardStorage = motherboardStorage;
        PowerUnitStorage = powerUnitStorage;
        VideoCardStorage = videocardStorage;
        CoolerStorage = coolerStorage;
        RamStorage = ramStorage;
        HddStorage = diskStorage;
        ComputerCaseStorage = computerCaseStorage;
        WiFiStorage = wifiStorage;
    }

    public IRepository<Cpu> CpuStorage { get; }
    public IRepository<Motherboard> MotherBoardStorage { get; }
    public IRepository<PowerUnit> PowerUnitStorage { get; }
    public IRepository<Videocard> VideoCardStorage { get; }
    public IRepository<Cooler> CoolerStorage { get; }
    public IRepository<Ram> RamStorage { get; }
    public IRepository<Disk> HddStorage { get; }
    public IRepository<ComputerCase> ComputerCaseStorage { get; }
    public IRepository<WiFi> WiFiStorage { get; }
}
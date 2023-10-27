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
        Repository<Cpu> cpuStorage,
        Repository<Motherboard> motherboardStorage,
        Repository<PowerUnit> powerUnitStorage,
        Repository<Videocard> videocardStorage,
        Repository<Cooler> coolerStorage,
        Repository<Ram> ramStorage,
        Repository<Disk> diskStorage,
        Repository<ComputerCase> computerCaseStorage,
        Repository<WiFi> wifiStorage)
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

    public IRepository<Cpu> CpuStorage { get; set; }
    public IRepository<Motherboard> MotherBoardStorage { get; set; }
    public IRepository<PowerUnit> PowerUnitStorage { get; set; }
    public IRepository<Videocard> VideoCardStorage { get; set; }
    public IRepository<Cooler> CoolerStorage { get; set; }
    public IRepository<Ram> RamStorage { get; set; }
    public IRepository<Disk> HddStorage { get; set; }
    public IRepository<ComputerCase> ComputerCaseStorage { get; set; }

    public IRepository<WiFi> WiFiStorage { get; set; }
}
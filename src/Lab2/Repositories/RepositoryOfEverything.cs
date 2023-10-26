using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPUFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIsks;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class RepositoryOfEverything
{
    public RepositoryOfEverything()
    {
        CpuStorage = new Repository<Cpu>();
        MotherBoardStorage = new Repository<Motherboard>();
        PowerUnitStorage = new Repository<PowerUnit>();
        VideoCardStorage = new Repository<Videocard>();
        CoolerStorage = new Repository<Cooler>();
        RamStorage = new Repository<Ram>();
        HddStorage = new Repository<Hdd>();
        ComputerCaseStorage = new Repository<ComputerCase>();
        WiFiStorage = new Repository<WiFi>();
    }

    public IRepository<Cpu> CpuStorage { get; set; }
    public IRepository<Motherboard> MotherBoardStorage { get; set; }
    public IRepository<PowerUnit> PowerUnitStorage { get; set; }
    public IRepository<Videocard> VideoCardStorage { get; set; }
    public IRepository<Cooler> CoolerStorage { get; set; }
    public IRepository<Ram> RamStorage { get; set; }
    public IRepository<Hdd> HddStorage { get; set; }
    public IRepository<ComputerCase> ComputerCaseStorage { get; set; }

    public IRepository<WiFi> WiFiStorage { get; set; }
}
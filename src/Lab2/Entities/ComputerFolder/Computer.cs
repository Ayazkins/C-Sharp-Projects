using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPUFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIsks;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;

public class Computer : DetailBase
{
    public Computer(
        string name,
        Motherboard motherboard,
        Videocard? videocard,
        Cpu cpu,
        IReadOnlyCollection<Hdd> disks,
        PowerUnit powerUnit,
        Cooler cooler,
        WiFi? wiFi,
        IReadOnlyCollection<Ram> rams,
        ComputerCase computerCase)
        : base(name)
    {
        Motherboard = motherboard;
        Videocard = videocard;
        Cpu = cpu;
        HddDisks = disks;
        PowerUnit = powerUnit;
        Cooler = cooler;
        WiFi = wiFi;
        Rams = rams;
        ComputerCase = computerCase;
    }

    public Motherboard Motherboard { get; }
    public ComputerCase ComputerCase { get; }
    public Videocard? Videocard { get; }
    public Cpu Cpu { get; }
    public IReadOnlyCollection<Hdd> HddDisks { get; }
    public PowerUnit PowerUnit { get; }
    public Cooler Cooler { get; }
    public WiFi? WiFi { get; }

    public IReadOnlyCollection<Ram> Rams { get; }

    public ComputerBuilder Direct(IValidator validator)
    {
        ComputerBuilder computerBuilder = new ComputerBuilder(validator)
            .SetName(Name)
            .SetVideocard(Videocard)
            .SetCase(ComputerCase)
            .SetCooler(Cooler)
            .SetCpu(Cpu)
            .SetDisks(HddDisks)
            .SetMotherboard(Motherboard)
            .SetRams(Rams)
            .SetPowerUnit(PowerUnit)
            .SetWiFi(WiFi);
        return computerBuilder;
    }
}
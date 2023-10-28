using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIskComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class Computer : DetailBase
{
    public Computer(
        string name,
        Motherboard motherboard,
        Videocard? videocard,
        Cpu cpu,
        IReadOnlyCollection<Disk> disks,
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
        Disks = disks;
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
    public IReadOnlyCollection<Disk> Disks { get; }
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
            .SetDisks(Disks)
            .SetMotherboard(Motherboard)
            .SetRams(Rams)
            .SetPowerUnit(PowerUnit)
            .SetWiFi(WiFi);
        return computerBuilder;
    }
}
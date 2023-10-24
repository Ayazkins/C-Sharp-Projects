using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPUFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIsks;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIEFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SocketFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;
using Xunit;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly BaseRepository<Cpu> _cpuStorage = new BaseRepository<Cpu>();
    private readonly BaseRepository<Motherboard> _motherboardStorage = new BaseRepository<Motherboard>();
    private readonly BaseRepository<Videocard> _videocardStorage = new BaseRepository<Videocard>();
    private readonly BaseRepository<Ram> _ramStorage = new BaseRepository<Ram>();
    private readonly BaseRepository<ComputerCase> _caseStorage = new BaseRepository<ComputerCase>();
    private readonly BaseRepository<Hdd> _diskStorage = new BaseRepository<Hdd>();
    private readonly BaseRepository<Cooler> _coolerStorage = new BaseRepository<Cooler>();
    private readonly BaseRepository<PowerUnit> _powerUnitStorage = new BaseRepository<PowerUnit>();
    private readonly BaseRepository<Computer> _computerStorage = new BaseRepository<Computer>();

    public Tests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        var cpuBuilder = new CpuBuilder();
        Cpu cpu = cpuBuilder
            .SetCores(4)
            .SetCoreFrequency(3.6)
            .SetName("Intel Core i3-10100F")
            .SetSocket(new Socket("LGA 1200"))
            .SetMemoryFrequency(2666)
            .SetTDP(65)
            .SetEnergyConsumption(100)
            .Build();
        Cpu diffCpu = cpuBuilder
            .SetName("AMD Ryzen")
            .SetSocket(new Socket("AM4"))
            .Build();
        _cpuStorage.Add(cpu);
        _cpuStorage.Add(diffCpu);

        var motherBoard = new MotherboardBuilder();
        var list = new List<Cpu>() { cpu };
        var listOfPcie = new List<Pcie>() { new Pcie("X16", 16), new Pcie("X1", 1) };
        Motherboard motherboard = motherBoard
            .SetSocket(new Socket("LGA 1200"))
            .SetName("MSI PRO H510M-B")
            .SetBios(new Bios("test", list, 1))
            .SetChipset(new Chipset("Intel H470", 3.66, true))
            .SetSata(4)
            .SetFormFactor(new FormFactor("Micro-ATX"))
            .SetRAM(2)
            .SetDDRVersion(new Ddr("DDR4"))
            .SetPCIE(listOfPcie)
            .Build();
        _motherboardStorage.Add(motherboard);

        var computerCaseBuilder = new CaseBuilder();
        var listOfFormFactors = new List<FormFactor>() { new FormFactor("Micro-ATX") };
        ComputerCase computerCase = computerCaseBuilder
            .SetName("AeroCool Bolt Mini")
            .SetHeight(381)
            .SetLength(370)
            .SetWidth(200)
            .SetLengthOfVideocard(320)
            .SetWidthOfVideocard(160)
            .SetFormFactors(listOfFormFactors)
            .Build();
        _caseStorage.Add(computerCase);

        var graphicCardBuilder = new VideocardBuilder();
        Videocard videocard = graphicCardBuilder
            .SetLength(178)
            .SetName("MSI GeForce GTX 1630 VENTUS XS OC")
            .SetWidth(112)
            .SetFrequency(12000)
            .SetMemory(4)
            .SetPci(new Pcie("X16", 16))
            .SetEnergyConsumption(75)
            .Build();
        _videocardStorage.Add(videocard);

        var sockets = new List<Socket>() { new Socket("LGA 1200") };
        var cooler = new Cooler("ID-COOLING SE-903-XT", 100, 123, 65, 130, sockets);
        _coolerStorage.Add(cooler);

        var ramBuilder = new RamBuilder();
        var profiles = new List<Profile>() { new Profile("Intel XMP", "XMP", 10, 1000, new List<int>() { 30, 50 }) };
        Ram ram = ramBuilder
            .SetName("ADATA XPG GAMMIX D20")
            .SetMemory(8)
            .SetEnergyConsumption(2)
            .SetFormFactor(new FormFactor("Micro-ATX"))
            .SetProfiles(profiles)
            .SetJedecVoltage(new List<JedecAndVoltage>() { new JedecAndVoltage(10, 10) })
            .SetDDR(new Ddr("DDR4"))
            .Build();
        _ramStorage.Add(ram);

        var ssd = new Ssd("Apacer AS350 PANTHER", 512, 550, 10, null);
        _diskStorage.Add(ssd);

        var powerUnit = new PowerUnit("AeroCool VX PLUS 500W", 500);
        _powerUnitStorage.Add(powerUnit);

        var computerBuilder = new ComputerBuilder();
        Computer computer = computerBuilder
            .SetName("Good pc")
            .SetCase(computerCase)
            .SetCooler(cooler)
            .SetCpu(cpu)
            .SetMotherboard(motherboard)
            .SetRams(new List<Ram>() { ram, ram })
            .SetDisks(new List<Hdd>() { ssd })
            .SetVideocard(videocard)
            .SetPowerUnit(powerUnit)
            .Build();
        _computerStorage.Add(computer);
    }

    [Fact]
    public void SuccessResultTest()
    {
        Computer computer = _computerStorage.GetDetail("Good pc");
        var computerValidator = new ComputerValidator();

        ValidatorResult result = computerValidator.Validate(computer);

        Assert.IsType<ValidatorResult.SuccessResult>(result);
    }

    [Fact]
    public void NotEnoughEnergyTest()
    {
        var powerUnit = new PowerUnit("AeroCool VX PLUS 500W", 10);
        ComputerBuilder computerBuilder = _computerStorage.GetDetail("Good pc").Direct();
        computerBuilder.SetPowerUnit(powerUnit);
        Computer computer = computerBuilder.Build();
        var computerValidator = new ComputerValidator();

        ValidatorResult result = computerValidator.Validate(computer);

        Assert.IsType<ValidatorResult.NoGuarantee>(result);
        Assert.Equal("NoGuarantee { Comment = May be not enough energy\n }", result.ToString());
    }

    [Fact]
    public void NotGreatCoolerTest()
    {
        CoolerBuilder coolerBuilder = _coolerStorage.GetDetail("ID-COOLING SE-903-XT").Direct().SetTdp(10);
        Cooler newCooler = coolerBuilder.Build();
        ComputerBuilder computerBuilder = _computerStorage.GetDetail("Good pc").Direct();
        computerBuilder.SetCooler(newCooler);
        Computer computer = computerBuilder.Build();
        var computerValidator = new ComputerValidator();

        ValidatorResult result = computerValidator.Validate(computer);

        Assert.IsType<ValidatorResult.NoGuarantee>(result);
        Assert.Equal("NoGuarantee { Comment = Tdp not enough\n }", result.ToString());
    }

    [Fact]
    public void WrongCpuInGoodPcTest()
    {
        ComputerBuilder computerBuilder = _computerStorage.GetDetail("Good pc").Direct()
            .SetCpu(_cpuStorage.GetDetail("AMD Ryzen"));
        Computer computer = computerBuilder.Build();
        var computerValidator = new ComputerValidator();

        ValidatorResult result = computerValidator.Validate(computer);
        Assert.IsType<ValidatorResult.Fault>(result);
        Assert.Equal(
            "Fault { Comment = Cpu and cooler have different sockets\n" +
            "Different cpu and motherboard sockets\n" +
            "Bios doesn't support cpu\n }",
            result.ToString());
    }

    [Fact]
    public void NoGraphicCardTest()
    {
        ComputerBuilder computerBuilder = _computerStorage.GetDetail("Good pc").Direct().SetVideocard(null);
        Computer computer = computerBuilder.Build();
        var computerValidator = new ComputerValidator();

        ValidatorResult result = computerValidator.Validate(computer);

        Assert.IsType<ValidatorResult.Fault>(result);
        Assert.Equal("Fault { Comment = No graphic card\n }", result.ToString());
    }
}
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
    private readonly RepositoryOfEverything _repository = new RepositoryOfEverything();
    private readonly ITestOutputHelper _outputHelper;

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
        _repository.CpuStorage.Add(cpu);
        _repository.CpuStorage.Add(diffCpu);

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
        _repository.MotherBoardStorage.Add(motherboard);

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
        _repository.ComputerCaseStorage.Add(computerCase);

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
        _repository.VideoCardStorage.Add(videocard);

        var sockets = new List<Socket>() { new Socket("LGA 1200") };
        var cooler = new Cooler("ID-COOLING SE-903-XT", 100, 123, 65, 130, sockets);
        _repository.CoolerStorage.Add(cooler);

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
        _repository.RamStorage.Add(ram);

        var ssd = new Ssd("Apacer AS350 PANTHER", 512, 550, 10, null);
        _repository.HddStorage.Add(ssd);

        var powerUnit = new PowerUnit("AeroCool VX PLUS 500W", 500);
        _repository.PowerUnitStorage.Add(powerUnit);
    }

    [Fact]
    public void SuccessResultTest()
    {
        var specification = new Specification(
            "Intel Core i3-10100F",
            "MSI PRO H510M-B",
            new List<string>() { "ADATA XPG GAMMIX D20", "ADATA XPG GAMMIX D20" },
            new List<string>() { "Apacer AS350 PANTHER" },
            "AeroCool VX PLUS 500W",
            null,
            "MSI GeForce GTX 1630 VENTUS XS OC",
            "AeroCool Bolt Mini",
            "ID-COOLING SE-903-XT");
        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        var computerBuilderDirector =
            new ComputerBuilderDirector(specification, _repository, computerBuilder);
        computerBuilderDirector.ComputerConstruct("Good Pc");
        PcBuildResult pcBuildResult = computerBuilder.Build();

        Assert.IsType<ValidatorResult.SuccessResult>(pcBuildResult.ValidatorResult);
    }

    [Fact]
    public void NotEnoughEnergyTest()
    {
        var powerUnit = new PowerUnit("AeroCool VX PLUS 10W", 10);
        _repository.PowerUnitStorage.Add(powerUnit);
        var specification = new Specification(
            "Intel Core i3-10100F",
            "MSI PRO H510M-B",
            new List<string>() { "ADATA XPG GAMMIX D20", "ADATA XPG GAMMIX D20" },
            new List<string>() { "Apacer AS350 PANTHER" },
            "AeroCool VX PLUS 10W",
            null,
            "MSI GeForce GTX 1630 VENTUS XS OC",
            "AeroCool Bolt Mini",
            "ID-COOLING SE-903-XT");
        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        var computerBuilderDirector =
            new ComputerBuilderDirector(specification, _repository, computerBuilder);
        computerBuilderDirector.ComputerConstruct("Good Pc");

        PcBuildResult pcBuildResult = computerBuilder.Build();

        Assert.IsType<ValidatorResult.NoGuarantee>(pcBuildResult.ValidatorResult);
        Assert.Equal("NoGuarantee { Comment = May be not enough energy\n }", pcBuildResult.ValidatorResult.ToString());
    }

    [Fact]
    public void NotGreatCoolerTest()
    {
        CoolerBuilder coolerBuilder = _repository.CoolerStorage.GetDetail("ID-COOLING SE-903-XT").Direct().SetTdp(10)
            .SetName("newCooler");
        Cooler newCooler = coolerBuilder.Build();
        _repository.CoolerStorage.Add(newCooler);
        var specification = new Specification(
            "Intel Core i3-10100F",
            "MSI PRO H510M-B",
            new List<string>() { "ADATA XPG GAMMIX D20", "ADATA XPG GAMMIX D20" },
            new List<string>() { "Apacer AS350 PANTHER" },
            "AeroCool VX PLUS 500W",
            null,
            "MSI GeForce GTX 1630 VENTUS XS OC",
            "AeroCool Bolt Mini",
            "newCooler");
        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        var computerBuilderDirector =
            new ComputerBuilderDirector(specification, _repository, computerBuilder);
        computerBuilderDirector.ComputerConstruct("Good Pc");

        PcBuildResult pcBuildResult = computerBuilder.Build();

        Assert.IsType<ValidatorResult.NoGuarantee>(pcBuildResult.ValidatorResult);
        Assert.Equal("NoGuarantee { Comment = Tdp not enough\n }", pcBuildResult.ValidatorResult.ToString());
    }

    [Fact]
    public void WrongCpuInGoodPcTest()
    {
        var specification = new Specification(
            "AMD Ryzen",
            "MSI PRO H510M-B",
            new List<string>() { "ADATA XPG GAMMIX D20", "ADATA XPG GAMMIX D20" },
            new List<string>() { "Apacer AS350 PANTHER" },
            "AeroCool VX PLUS 500W",
            null,
            "MSI GeForce GTX 1630 VENTUS XS OC",
            "AeroCool Bolt Mini",
            "ID-COOLING SE-903-XT");
        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        var computerBuilderDirector =
            new ComputerBuilderDirector(specification, _repository, computerBuilder);
        computerBuilderDirector.ComputerConstruct("Good Pc");

        PcBuildResult pcBuildResult = computerBuilder.Build();

        Assert.IsType<ValidatorResult.Fault>(pcBuildResult.ValidatorResult);
        Assert.Equal(
            "Fault { Comment = Cpu and cooler have different sockets\n" +
            "Different cpu and motherboard sockets\n" +
            "Bios doesn't support cpu\n }",
            pcBuildResult.ValidatorResult.ToString());
    }

    [Fact]
    public void NoGraphicCardTest()
    {
        var specification = new Specification(
            "Intel Core i3-10100F",
            "MSI PRO H510M-B",
            new List<string>() { "ADATA XPG GAMMIX D20", "ADATA XPG GAMMIX D20" },
            new List<string>() { "Apacer AS350 PANTHER" },
            "AeroCool VX PLUS 500W",
            null,
            null,
            "AeroCool Bolt Mini",
            "ID-COOLING SE-903-XT");
        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        var computerBuilderDirector =
            new ComputerBuilderDirector(specification, _repository, computerBuilder);
        computerBuilderDirector.ComputerConstruct("Good Pc");

        PcBuildResult pcBuildResult = computerBuilder.Build();

        Assert.IsType<ValidatorResult.Fault>(pcBuildResult.ValidatorResult);
        Assert.Equal("Fault { Comment = No graphic card\n }", pcBuildResult.ValidatorResult.ToString());
        Assert.Null(pcBuildResult.Pc);
    }
}
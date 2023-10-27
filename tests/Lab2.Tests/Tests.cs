using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BiosComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIskComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamProfileComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    private readonly RepositoryOfEverything _repository;
    private readonly Specification _defaultSpecification;

    public Tests()
    {
        var cpuStorage = new Repository<Cpu>();
        var motherboardStorage = new Repository<Motherboard>();
        var videocardStorage = new Repository<Videocard>();
        var ramStorage = new Repository<Ram>();
        var caseStorage = new Repository<ComputerCase>();
        var diskStorage = new Repository<Disk>();
        var coolerStorage = new Repository<Cooler>();
        var powerUnitStorage = new Repository<PowerUnit>();
        var cpuBuilder = new CpuBuilder();
        Cpu cpu = cpuBuilder
            .SetCores(4)
            .SetCoreFrequency(3.6)
            .SetName("Intel Core i3-10100F")
            .SetSocket(new Socket("LGA 1200"))
            .SetMemoryFrequency(2666)
            .SetTdp(65)
            .SetEnergyConsumption(100)
            .Build();
        Cpu diffCpu = cpuBuilder
            .SetName("AMD Ryzen")
            .SetSocket(new Socket("AM4"))
            .Build();
        cpuStorage.Add(cpu);
        cpuStorage.Add(diffCpu);

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
            .SetRam(2)
            .SetDdrVersion(new Ddr("DDR4"))
            .SetPcie(listOfPcie)
            .Build();
        motherboardStorage.Add(motherboard);

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
        caseStorage.Add(computerCase);

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
        videocardStorage.Add(videocard);

        var sockets = new List<Socket>() { new Socket("LGA 1200") };
        var cooler = new Cooler("ID-COOLING SE-903-XT", 100, 123, 65, 130, sockets);
        coolerStorage.Add(cooler);

        var ramBuilder = new RamBuilder();
        var profiles = new List<RamProfile>()
            { new RamProfile("Intel XMP", "XMP", 10, 1000, new List<int>() { 30, 50 }) };
        Ram ram = ramBuilder
            .SetName("ADATA XPG GAMMIX D20")
            .SetMemory(8)
            .SetEnergyConsumption(2)
            .SetFormFactor(new FormFactor("Micro-ATX"))
            .SetProfiles(profiles)
            .SetJedecVoltage(new List<JedecAndVoltage>() { new JedecAndVoltage(10, 10) })
            .SetDDR(new Ddr("DDR4"))
            .Build();
        ramStorage.Add(ram);

        var ssd = new Disk("Apacer AS350 PANTHER", 512, 550, 10);
        diskStorage.Add(ssd);

        var powerUnit = new PowerUnit("AeroCool VX PLUS 500W", 500);
        powerUnitStorage.Add(powerUnit);
        _repository = new RepositoryOfEverything(
            cpuStorage,
            motherboardStorage,
            powerUnitStorage,
            videocardStorage,
            coolerStorage,
            ramStorage,
            diskStorage,
            caseStorage,
            new Repository<WiFi>());
        _defaultSpecification = new Specification(
            "Good pc",
            "Intel Core i3-10100F",
            "MSI PRO H510M-B",
            new List<string>() { "ADATA XPG GAMMIX D20", "ADATA XPG GAMMIX D20" },
            new List<string>() { "Apacer AS350 PANTHER" },
            "AeroCool VX PLUS 500W",
            null,
            "MSI GeForce GTX 1630 VENTUS XS OC",
            "AeroCool Bolt Mini",
            "ID-COOLING SE-903-XT");
    }

    [Fact]
    public void SuccessResultTest()
    {
        Specification specification = _defaultSpecification;
        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        Computer? computer = new ComputerBuilderDirector(specification, _repository)
            .ComputerConstruct(computerBuilder);

        Assert.IsType<ValidatorResult.SuccessResult>(computerBuilder.ValidatorResult);
        Assert.NotNull(computer);
    }

    [Fact]
    public void NotEnoughEnergyTest()
    {
        var powerUnit = new PowerUnit("AeroCool VX PLUS 10W", 10);
        _repository.PowerUnitStorage.Add(powerUnit);
        Specification specification = _defaultSpecification;
        specification.PowerUnitName = "AeroCool VX PLUS 10W";
        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        Computer? computer = new ComputerBuilderDirector(specification, _repository)
            .ComputerConstruct(computerBuilder);

        Assert.IsType<ValidatorResult.NoGuarantee>(computerBuilder.ValidatorResult);
        Assert.NotNull(computer);
    }

    [Fact]
    public void NotGreatCoolerTest()
    {
        CoolerBuilder coolerBuilder = _repository.CoolerStorage.GetDetail("ID-COOLING SE-903-XT").Direct().SetTdp(10)
            .SetName("newCooler");
        Cooler newCooler = coolerBuilder.Build();
        _repository.CoolerStorage.Add(newCooler);
        Specification specification = _defaultSpecification;
        specification.CoolerName = "newCooler";
        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        Computer? computer = new ComputerBuilderDirector(specification, _repository)
            .ComputerConstruct(computerBuilder);

        Assert.IsType<ValidatorResult.NoGuarantee>(computerBuilder.ValidatorResult);
        Assert.NotNull(computer);
    }

    [Fact]
    public void WrongCpuInGoodPcTest()
    {
        Specification specification = _defaultSpecification;
        _defaultSpecification.CpuName = "AMD Ryzen";
        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        Computer? computer = new ComputerBuilderDirector(specification, _repository)
            .ComputerConstruct(computerBuilder);

        Assert.IsType<ValidatorResult.Fault>(computerBuilder.ValidatorResult);
        Assert.Null(computer);
    }

    [Fact]
    public void NoGraphicCardTest()
    {
        Specification specification = _defaultSpecification;
        _defaultSpecification.VideocardName = null;

        var computerBuilder = new ComputerBuilder(new ComputerValidator());
        Computer? computer = new ComputerBuilderDirector(specification, _repository)
            .ComputerConstruct(computerBuilder);

        Assert.IsType<ValidatorResult.Fault>(computerBuilder.ValidatorResult);
        Assert.Null(computer);
    }
}
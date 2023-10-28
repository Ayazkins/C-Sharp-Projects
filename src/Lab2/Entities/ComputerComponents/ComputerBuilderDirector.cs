using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIskComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class ComputerBuilderDirector : IDirector
{
    private RepositoryOfEverything _repositoryOfEverything;
    private Specification _specification;

    public ComputerBuilderDirector(
        Specification specification,
        RepositoryOfEverything repositoryOfEverything)
    {
        _specification = specification;
        _repositoryOfEverything = repositoryOfEverything;
    }

    public Computer ComputerConstruct(ComputerBuilder computerBuilder)
    {
        if (computerBuilder == null)
        {
            throw new ArgumentNullException(nameof(computerBuilder));
        }

        var hdds = new List<Disk>();
        foreach (string diskName in _specification.DiskNames)
        {
            hdds.Add(_repositoryOfEverything.HddStorage.GetDetail(diskName));
        }

        var rams = new List<Ram>();
        foreach (string diskName in _specification.RamName)
        {
            rams.Add(_repositoryOfEverything.RamStorage.GetDetail(diskName));
        }

        computerBuilder
            .SetCooler(_repositoryOfEverything.CoolerStorage.GetDetail(_specification.CoolerName))
            .SetMotherboard(_repositoryOfEverything.MotherBoardStorage.GetDetail(_specification.MotherboardName))
            .SetName(_specification.Name)
            .SetCase(_repositoryOfEverything.ComputerCaseStorage.GetDetail(_specification.ComputerCaseName))
            .SetCpu(_repositoryOfEverything.CpuStorage.GetDetail(_specification.CpuName))
            .SetDisks(hdds)
            .SetRams(rams)
            .SetPowerUnit(_repositoryOfEverything.PowerUnitStorage.GetDetail(_specification.PowerUnitName));
        if (_specification.WiFiName != null)
        {
            computerBuilder.SetWiFi(_repositoryOfEverything.WiFiStorage.GetDetail(_specification.WiFiName));
        }

        if (_specification.VideocardName != null)
        {
            computerBuilder.SetVideocard(
                _repositoryOfEverything.VideoCardStorage.GetDetail(_specification.VideocardName));
        }

        return computerBuilder.Build();
    }
}
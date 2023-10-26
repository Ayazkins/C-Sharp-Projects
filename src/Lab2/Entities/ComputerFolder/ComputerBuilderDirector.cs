using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIsks;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;

public class ComputerBuilderDirector
{
    private RepositoryOfEverything _repositoryOfEverything;
    private Specification _specification;
    private ComputerBuilder _computerBuilder;

    public ComputerBuilderDirector(
        Specification specification,
        RepositoryOfEverything repositoryOfEverything,
        ComputerBuilder computerBuilder)
    {
        _specification = specification;
        _repositoryOfEverything = repositoryOfEverything;
        _computerBuilder = computerBuilder;
    }

    public void ComputerConstruct(string name)
    {
        var hdds = new List<Hdd>();
        foreach (string diskName in _specification.DiskNames)
        {
            hdds.Add(_repositoryOfEverything.HddStorage.GetDetail(diskName));
        }

        var rams = new List<Ram>();
        foreach (string diskName in _specification.RamName)
        {
            rams.Add(_repositoryOfEverything.RamStorage.GetDetail(diskName));
        }

        _computerBuilder
            .SetCooler(_repositoryOfEverything.CoolerStorage.GetDetail(_specification.CoolerName))
            .SetMotherboard(_repositoryOfEverything.MotherBoardStorage.GetDetail(_specification.MotherboardName))
            .SetName(name)
            .SetCase(_repositoryOfEverything.ComputerCaseStorage.GetDetail(_specification.ComputerCaseName))
            .SetCpu(_repositoryOfEverything.CpuStorage.GetDetail(_specification.CpuName))
            .SetDisks(hdds)
            .SetRams(rams)
            .SetPowerUnit(_repositoryOfEverything.PowerUnitStorage.GetDetail(_specification.PowerUnitName));
        if (_specification.WiFiName != null)
        {
            _computerBuilder.SetWiFi(_repositoryOfEverything.WiFiStorage.GetDetail(_specification.WiFiName));
        }

        if (_specification.VideocardName != null)
        {
            _computerBuilder.SetVideocard(
                _repositoryOfEverything.VideoCardStorage.GetDetail(_specification.VideocardName));
        }
    }
}
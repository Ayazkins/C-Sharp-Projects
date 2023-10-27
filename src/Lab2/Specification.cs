using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Specification
{
    public Specification(
        string computerName,
        string cpuName,
        string motherboardName,
        IReadOnlyCollection<string> ramName,
        IReadOnlyCollection<string> diskNames,
        string powerUnitName,
        string? wiFiName,
        string? videocardName,
        string computerCaseName,
        string coolerName)
    {
        Name = computerName;
        CpuName = cpuName;
        MotherboardName = motherboardName;
        RamName = ramName;
        DiskNames = diskNames;
        PowerUnitName = powerUnitName;
        WiFiName = wiFiName;
        VideocardName = videocardName;
        ComputerCaseName = computerCaseName;
        CoolerName = coolerName;
    }

    public string CpuName { get; set; }

    public string Name { get; set; }
    public string MotherboardName { get; set; }
    public IReadOnlyCollection<string> RamName { get; set; }
    public IReadOnlyCollection<string> DiskNames { get; set; }
    public string PowerUnitName { get; set; }
    public string? WiFiName { get; set; }
    public string? VideocardName { get; set; }
    public string ComputerCaseName { get; set; }
    public string CoolerName { get; set; }
    }
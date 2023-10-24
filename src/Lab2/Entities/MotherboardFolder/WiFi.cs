using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIEFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;

public class WiFi : DetailBase
{
    public WiFi(string version, bool bluetooth, int energy, Pcie pcie)
        : base(version)
    {
        Bluetooth = bluetooth;
        EnergyConsumption = energy;
        Pcie = pcie;
    }

    public bool Bluetooth { get; }
    public int EnergyConsumption { get; }
    public Pcie Pcie { get; }
}
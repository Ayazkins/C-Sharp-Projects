using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;

public class WiFi : DetailBase
{
    public WiFi(string version, bool bluetooth, int energy, Pcie pcie)
        : base(version)
    {
        if (energy <= 0)
        {
            throw new NotPositiveValue(nameof(energy));
        }

        Bluetooth = bluetooth;
        EnergyConsumption = energy;
        Pcie = pcie;
    }

    public bool Bluetooth { get; }
    public int EnergyConsumption { get; }
    public Pcie Pcie { get; }
}
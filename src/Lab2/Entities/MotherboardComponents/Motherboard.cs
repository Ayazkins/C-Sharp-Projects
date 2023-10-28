using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BiosComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;

public class Motherboard : DetailBase
{
    public Motherboard(
        string name,
        Socket socket,
        IReadOnlyCollection<Pcie> pcies,
        int amountOfSata,
        Bios bios,
        FormFactor formFactor,
        int amountOfRam,
        Ddr ddrVersion,
        Chipset chipset,
        WiFi? wifi)
        : base(name)
    {
        if (amountOfRam <= 0)
        {
            throw new NotPositiveValue(nameof(amountOfRam));
        }

        if (amountOfSata <= 0)
        {
            throw new NotPositiveValue(nameof(amountOfSata));
        }

        Socket = socket;
        Pcies = pcies;
        AmountOfSata = amountOfSata;
        Bios = bios;
        FormFactor = formFactor;
        AmountOfRam = amountOfRam;
        DdrVersion = ddrVersion;
        Chipset = chipset;
        Wifi = wifi;
    }

    public Socket Socket { get; }
    public IReadOnlyCollection<Pcie> Pcies { get; }
    public int AmountOfSata { get; }
    public Bios Bios { get; }
    public FormFactor FormFactor { get; }
    public int AmountOfRam { get; }
    public Ddr DdrVersion { get; }
    public Chipset Chipset { get; }
    public WiFi? Wifi { get; }

    public MotherboardBuilder Direct()
    {
        MotherboardBuilder motherboardBuilder = new MotherboardBuilder()
            .SetName(Name)
            .SetBios(Bios)
            .SetChipset(Chipset)
            .SetFormFactor(FormFactor)
            .SetSata(AmountOfSata)
            .SetSocket(Socket)
            .SetRam(AmountOfRam)
            .SetDdrVersion(DdrVersion)
            .SetPcie(Pcies)
            .SetWifi(Wifi);
        return motherboardBuilder;
    }
}
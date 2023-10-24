using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIEFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SocketFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;

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
            .SetRAM(AmountOfRam)
            .SetDDRVersion(DdrVersion)
            .SetPCIE(Pcies)
            .SetWIFI(Wifi);
        return motherboardBuilder;
    }
}
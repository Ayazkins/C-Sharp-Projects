using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIEFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;
using Socket = Itmo.ObjectOrientedProgramming.Lab2.Entities.SocketFolder.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;

public class MotherboardBuilder
{
    private string? _name;
    private Socket? _socket;
    private IReadOnlyCollection<Pcie>? _pcies;
    private int _amountOfSata;
    private Bios? _bios;
    private FormFactor? _formFactor;
    private int _amountOfRam;
    private Ddr? _ddrVersion;
    private Chipset? _chipset;
    private WiFi? _wifi;

    public MotherboardBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public MotherboardBuilder SetFormFactor(FormFactor val)
    {
        _formFactor = val;
        return this;
    }

    public MotherboardBuilder SetPCIE(IReadOnlyCollection<Pcie> pcies)
    {
        _pcies = pcies;
        return this;
    }

    public MotherboardBuilder SetSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public MotherboardBuilder SetSata(int amout)
    {
        _amountOfSata = amout;
        return this;
    }

    public MotherboardBuilder SetBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public MotherboardBuilder SetRAM(int amout)
    {
        _amountOfRam = amout;
        return this;
    }

    public MotherboardBuilder SetDDRVersion(Ddr ddr)
    {
        _ddrVersion = ddr;
        return this;
    }

    public MotherboardBuilder SetChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder SetWIFI(WiFi? wiFi)
    {
        _wifi = wiFi;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _pcies ?? throw new ArgumentNullException(nameof(_pcies)),
            _amountOfSata,
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _amountOfRam,
            _ddrVersion ?? throw new ArgumentNullException(nameof(_ddrVersion)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _wifi);
    }
}
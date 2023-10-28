using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BiosComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;

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

    public MotherboardBuilder SetPcie(IReadOnlyCollection<Pcie> pcies)
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

    public MotherboardBuilder SetRam(int amout)
    {
        _amountOfRam = amout;
        return this;
    }

    public MotherboardBuilder SetDdrVersion(Ddr ddr)
    {
        _ddrVersion = ddr;
        return this;
    }

    public MotherboardBuilder SetChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder SetWifi(WiFi? wiFi)
    {
        _wifi = wiFi;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _name ?? throw new ObjectShouldBeNotNull(nameof(_name)),
            _socket ?? throw new ObjectShouldBeNotNull(nameof(_socket)),
            _pcies ?? throw new ObjectShouldBeNotNull(nameof(_pcies)),
            _amountOfSata,
            _bios ?? throw new ObjectShouldBeNotNull(nameof(_bios)),
            _formFactor ?? throw new ObjectShouldBeNotNull(nameof(_formFactor)),
            _amountOfRam,
            _ddrVersion ?? throw new ObjectShouldBeNotNull(nameof(_ddrVersion)),
            _chipset ?? throw new ObjectShouldBeNotNull(nameof(_chipset)),
            _wifi);
    }
}
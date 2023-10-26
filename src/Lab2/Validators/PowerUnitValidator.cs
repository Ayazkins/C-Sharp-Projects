using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIsks;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class PowerUnitValidator : IValidator
{
    private readonly string _notEnoughEnergy = "May be not enough energy\n";

    public ValidatorResult Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (CompareEnergy(computer))
        {
            return new ValidatorResult.SuccessResult();
        }

        return new ValidatorResult.NoGuarantee(_notEnoughEnergy);
    }

    private bool CompareEnergy(Computer computer)
    {
        int energyConsumption = 0;
        if (computer.Videocard != null) energyConsumption += computer.Videocard.EnergyConsumption;

        if (computer.WiFi != null) energyConsumption += computer.WiFi.EnergyConsumption;
        energyConsumption += computer.Cpu.EnergyConsumption;
        foreach (Hdd disk in computer.HddDisks)
        {
            energyConsumption += disk.EnergyConsumption;
        }

        foreach (Ram ram in computer.Rams)
        {
            energyConsumption += ram.EnergyConsumption;
        }

        return energyConsumption < computer.PowerUnit.Energy;
    }
}
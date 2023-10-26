using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class MotherboardAndRamValidator : IValidator
{
    private readonly string _slotsFault = "Not enough ram slots\n";
    private readonly string _formFactorFault = "Motherboard and ram have different form factors\n";
    private readonly string _ddrFault = "Motherboard and ram have different ddr version\n";

    public ValidatorResult Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (!CheckSlots(computer.Motherboard, computer.Rams))
        {
            return new ValidatorResult.Fault(_slotsFault);
        }

        foreach (Ram ram in computer.Rams)
        {
            if (!CheckFormFactor(computer.Motherboard, ram))
            {
                return new ValidatorResult.Fault(_formFactorFault);
            }

            if (!CheckDdr(computer.Motherboard, ram))
            {
                return new ValidatorResult.Fault(_ddrFault);
            }
        }

        return new ValidatorResult.SuccessResult();
    }

    private bool CheckFormFactor(Motherboard motherboard, Ram ram)
    {
        return motherboard.FormFactor.Name == ram.FormFactor.Name;
    }

    private bool CheckDdr(Motherboard motherboard, Ram ram)
    {
        return motherboard.DdrVersion.Name == ram.Ddr.Name;
    }

    private bool CheckSlots(Motherboard motherboard, IReadOnlyCollection<Ram> rams)
    {
        return motherboard.AmountOfRam >= rams.Count;
    }
}
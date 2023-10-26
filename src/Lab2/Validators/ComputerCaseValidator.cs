using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class ComputerCaseValidator : IValidator
{
    private readonly string _formfactorFault = "Case and motherboard have different form factors\n";
    private readonly string _videocardFault = "Videocard is too big for this case\n";

    public ValidatorResult Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Videocard != null && !CheckVideoCard(computer.ComputerCase, computer.Videocard))
        {
            return new ValidatorResult.Fault(_videocardFault);
        }

        if (!CheckFormFactors(computer.ComputerCase, computer.Motherboard))
        {
            return new ValidatorResult.Fault(_formfactorFault);
        }

        return new ValidatorResult.SuccessResult();
    }

    private bool CheckVideoCard(ComputerCase computerCase, Videocard videocard)
    {
        return videocard.Length <= computerCase.LengthOfVideocard && videocard.Width <= computerCase.WidthOfVideocard;
    }

    private bool CheckFormFactors(ComputerCase computerCase, Motherboard motherboard)
    {
        foreach (FormFactor formFactor in computerCase.SupportedFormFactor)
        {
            if (motherboard.FormFactor.Name == formFactor.Name)
            {
                return true;
            }
        }

        return false;
    }
}
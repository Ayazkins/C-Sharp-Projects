using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class WiFiValidator : IValidator
{
    private readonly string _wiFiFault = "There are two WiFi adapters\n";

    public ValidatorResult Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.WiFi != null && computer.Motherboard.Wifi != null)
        {
            return new ValidatorResult.Fault(_wiFiFault);
        }

        return new ValidatorResult.SuccessResult();
    }
}
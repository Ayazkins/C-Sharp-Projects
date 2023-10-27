using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class CpuAndVideocard : IValidator
{
    private readonly string _noVideoFault = "No graphic card\n";

    public ValidatorResult Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (!computer.Cpu.Videocard && computer.Videocard == null)
        {
            return new ValidatorResult.Fault(_noVideoFault);
        }

        return new ValidatorResult.SuccessResult();
    }
}
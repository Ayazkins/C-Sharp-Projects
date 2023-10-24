using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class ComputerValidator : IValidators
{
    private IReadOnlyCollection<IValidators> _validators;

    public ComputerValidator()
    {
        _validators = new List<IValidators>()
        {
            new PcieValidators(),
            new ComputerCaseValidator(),
            new CpuAndVideocard(),
            new WiFiValidator(),
            new PowerUnitValidator(),
            new CpuAndCoolerValidator(),
            new CpuAndMotherboardCheck(),
            new MotherboardAndRamValidator(),
        };
        Faults = new List<ValidatorResult>();
        Warnings = new List<ValidatorResult>();
    }

    public ICollection<ValidatorResult> Faults { get; }
    public ICollection<ValidatorResult> Warnings { get; }

    public ValidatorResult Validate(Computer computer)
    {
        CollectComments(computer);
        if (Faults.Count != 0)
        {
            string comment = string.Empty;
            foreach (ValidatorResult.Fault validatorResult in Faults)
            {
                comment += validatorResult.Comment;
            }

            return new ValidatorResult.Fault(comment);
        }

        if (Warnings.Count != 0)
        {
            string comment = string.Empty;
            foreach (ValidatorResult.NoGuarantee validatorResult in Warnings)
            {
                comment += validatorResult.Comment;
            }

            return new ValidatorResult.NoGuarantee(comment);
        }

        return new ValidatorResult.SuccessResult();
    }

    private void CollectComments(Computer computer)
    {
        foreach (IValidators validator in _validators)
        {
            ValidatorResult validatorResult = validator.Validate(computer);
            if (validatorResult is ValidatorResult.Fault)
            {
                Faults.Add(validatorResult);
            }

            if (validatorResult is ValidatorResult.NoGuarantee)
            {
                Warnings.Add(validatorResult);
            }
        }
    }
}
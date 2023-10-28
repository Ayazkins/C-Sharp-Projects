using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public class PcBuildResult
{
    public PcBuildResult(Computer? pc, ValidatorResult validatorResult)
    {
        Pc = pc;
        ValidatorResult = validatorResult;
    }

    public Computer? Pc { get; }
    public ValidatorResult ValidatorResult { get; }
}
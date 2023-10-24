using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public interface IValidators
{
    public ValidatorResult Validate(Computer computer);
}
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public interface IValidator
{
    public ValidatorResult Validate(Computer computer);
}
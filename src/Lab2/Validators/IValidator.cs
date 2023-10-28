using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public interface IValidator
{
    public ValidatorResult Validate(Computer computer);
}
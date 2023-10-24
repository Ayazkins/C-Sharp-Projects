namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public abstract record ValidatorResult
{
    private ValidatorResult() { }

    public record SuccessResult() : ValidatorResult;

    public record NoGuarantee(string Comment) : ValidatorResult;

    public record Fault(string Comment) : ValidatorResult;
}
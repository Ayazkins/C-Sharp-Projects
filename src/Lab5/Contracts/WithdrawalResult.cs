namespace Contracts;

public abstract record WithdrawalResult
{
    private WithdrawalResult() { }

    public sealed record Success : WithdrawalResult;

    public sealed record Fault : WithdrawalResult;
}
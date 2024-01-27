namespace Contracts;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success : LoginResult;

    public sealed record Fault : LoginResult;
}
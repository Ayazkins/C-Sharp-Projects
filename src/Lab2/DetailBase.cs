namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class DetailBase
{
    protected DetailBase(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
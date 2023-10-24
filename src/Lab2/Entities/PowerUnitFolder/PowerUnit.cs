namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnitFolder;

public class PowerUnit : DetailBase
{
    public PowerUnit(string name, int energy)
        : base(name)
    {
        Energy = energy;
    }

    public int Energy { get; set; }
}
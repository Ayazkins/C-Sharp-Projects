using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactory;

public class Vaklas : ShipFactory
{
    public override bool Nithrin()
    {
        return false;
    }

    public override DeflectorBase CreateDeflector(bool add = false)
    {
        return new DeflectorClass1(add);
    }

    public override EngineBase CreateEngine()
    {
        return new EngineClassE();
    }

    public override JumpEngineBase CreateJumpEngine()
    {
        return new JumpEngineGamma();
    }

    public override ShellBase CreateShell()
    {
        return new ShellClass2();
    }

    public override string GiveName()
    {
        return "Vaklas";
    }
}
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactory;

public class Meredian : ShipFactory
{
    public override bool Nithrin()
    {
        return true;
    }

    public override DeflectorBase CreateDeflector(bool add = false)
    {
        return new DeflectorClass2();
    }

    public override EngineBase CreateEngine()
    {
        return new EngineClassE();
    }

    public override ShellBase CreateShell()
    {
        return new ShellClass2();
    }

    public override JumpEngineBase CreateJumpEngine()
    {
        return new NullJumpEngine();
    }

    public override string GiveName()
    {
        return "Meredian";
    }
}
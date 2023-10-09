using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactory;

public class Walker : ShipFactory
{
    public override bool Nithrin()
    {
        return false;
    }

    public override DeflectorBase CreateDeflector(bool add = false)
    {
        return new NullDeflector();
    }

    public override EngineBase CreateEngine()
    {
        return new EngineClassC();
    }

    public override ShellBase CreateShell()
    {
        return new ShellClassFirst();
    }

    public override JumpEngineBase CreateJumpEngine()
    {
        return new NullJumpEngine();
    }

    public override string GiveName()
    {
        return "Walker";
    }
}
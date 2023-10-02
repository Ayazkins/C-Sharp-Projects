using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactory;

public class Avgur : ShipFactory
{
    public override bool Nithrin()
    {
        return false;
    }

    public override DeflectorBase CreateDeflector(bool add = false)
    {
        return new DeflectorClass3();
    }

    public override EngineBase CreateEngine()
    {
        return new EngineClassE();
    }

    public override ShellBase CreateShell()
    {
        return new ShellClass3();
    }

    public override JumpEngineBase CreateJumpEngine()
    {
        return new JumpEngineAlpha();
    }

    public override string GiveName()
    {
        return "Avgur";
    }
}
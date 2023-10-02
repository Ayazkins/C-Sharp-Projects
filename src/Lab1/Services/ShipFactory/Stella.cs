using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactory;

public class Stella : ShipFactory
{
    public override bool Nithrin()
    {
        return false;
    }

    public override DeflectorBase CreateDeflector(bool add = false)
    {
        return new DeflectorClass1();
    }

    public override EngineBase CreateEngine()
    {
        return new EngineClassC();
    }

    public override ShellBase CreateShell()
    {
        return new ShellClass1();
    }

    public override JumpEngineBase CreateJumpEngine()
    {
        return new JumpEngineOmega();
    }

    public override string GiveName()
    {
        return "Stella";
    }
}